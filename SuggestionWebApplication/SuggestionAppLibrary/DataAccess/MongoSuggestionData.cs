using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using SuggestionAppLibrary.Models;
using MongoDB.Driver;

namespace SuggestionAppLibrary.DataAccess
{
    public class MongoSuggestionData : ISuggestionData
    {
        private readonly IMongoCollection<SuggestionModel> _suggestions;
        private readonly IDbconnection _db;
        private readonly IMemoryCache _cache;
        private readonly IUserData _userdata;
        private const string cacheName = "SuggestionData";

        public MongoSuggestionData(IDbconnection dbconnection, IMemoryCache cache, IUserData userdata)
        {

            _suggestions = dbconnection.SuggestionCollection;
            _db = dbconnection;
            _cache = cache;
            _userdata = userdata;
        }

        public async Task<List<SuggestionModel>> GetAllSuggestions()
        {
            var output = _cache.Get<List<SuggestionModel>>(cacheName);

            if (output == null)
            {
                var result = await _suggestions.FindAsync(_ => true);
                output = result.ToList();

                _cache.Set(cacheName, output, TimeSpan.FromMinutes(value: 1));
            }


            return output;
        }


        public async Task<List<SuggestionModel>> GetAllAprrovedSuggestions()
        {
            var result = await GetAllSuggestions();
            return result.Where(x => x.ApprovedForRelease == true).ToList();
        }

        //get from database instead of cache for the lastest data
        public async Task<SuggestionModel> GetSuggestion(string id)
        {

            var result = await _suggestions.FindAsync(x => x.Id == id);
            return result.FirstOrDefault();

        }

        public async Task<List<SuggestionModel>> GetAllSuggestionsWaitingForApproval()
        {
            var result = await GetAllSuggestions();
            return result.Where(x => x.ApprovedForRelease == false && x.Rejected == false).ToList();

        }

        public async Task UpdateSuggestion(SuggestionModel suggestion)
        {
            await _suggestions.ReplaceOneAsync(x => x.Id == suggestion.Id, suggestion);
            _cache.Remove(cacheName);
        }

        public async Task UpVoteSuggestions(string suggestionId, string userId)
        {
            var client = _db.Client;

            //intialize a session 
            using var session = await client.StartSessionAsync();

            //start the session
            session.StartTransaction();

            try
            {
                var db = client.GetDatabase(_db.DbName);
                var suggestionCollectionInTransaction = db.GetCollection<SuggestionModel>(_db.SuggetionCollectionName);
                var suggestion = (await suggestionCollectionInTransaction.FindAsync(x => x.Id == suggestionId)).FirstOrDefault();

                bool isUpvote = suggestion.UserVotes.Add(userId);


                if (!isUpvote)
                {
                    suggestion.UserVotes.Remove(userId);
                }

                await suggestionCollectionInTransaction.ReplaceOneAsync(session,x => x.Id == suggestionId, suggestion);



                var UserCollectionInTransaction = db.GetCollection<UserModel>(_db.UserCollectionName);
                var user = (await UserCollectionInTransaction.FindAsync(x => x.Id == userId)).FirstOrDefault();


                if (!isUpvote)
                {
                    var suggestionToRemove = user.VotedOnSuggestions.Where(x => x.Id == suggestionId).First();
                    user.VotedOnSuggestions.Remove(suggestionToRemove);
                }
                else
                {
                    user.VotedOnSuggestions.Add(new BasicSuggestionModel(suggestion));
                }

                await UserCollectionInTransaction.ReplaceOneAsync(session,x => x.Id == userId, user);

                await session.CommitTransactionAsync();

                _cache.Remove(cacheName);



            }
            catch (Exception ex)
            {
                await session.AbortTransactionAsync();
                throw;
            }

        }



        public async Task CreateSuggestion(SuggestionModel suggestion)
        {
            var client = _db.Client;


            //create session
            using var session = await client.StartSessionAsync();
            session.StartTransaction();

            try
            {
                var db = client.GetDatabase(_db.DbName);
                var suggestionCollectionInTransaction = db.GetCollection<SuggestionModel>(_db.SuggetionCollectionName);
                await suggestionCollectionInTransaction.InsertOneAsync(session, suggestion);

                var userCollectionInTransaction = db.GetCollection<UserModel>(_db.UserCollectionName);
                var user = (await userCollectionInTransaction.FindAsync(x => x.Id == suggestion.Author.Id)).First();
                user.AnchoredSuggestions.Add(item: new BasicSuggestionModel(suggestion));
                await userCollectionInTransaction.ReplaceOneAsync(session,x => x.Id == user.Id, user);

                await session.CommitTransactionAsync();
            }

            catch (Exception ex)
            {
                //stop session
                await session.AbortTransactionAsync();
                throw;
            }



        }

        public async Task<List<SuggestionModel>> GetSuggestionsByUser(string userId)
        {
            var result = _cache.Get<List<SuggestionModel>>(userId);

            if (result ==null)
            {
                var output = await _suggestions.FindAsync(x => x.Author.Id == userId);
                result = output.ToList();
                _cache.Set(userId, result, TimeSpan.FromMinutes(1));

            }

            return result;
        }

    }
}
