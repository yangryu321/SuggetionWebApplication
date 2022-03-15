using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using SuggestionAppLibrary.Models;

namespace SuggestionAppLibrary.DataAccess
{
    public class MongoUserData : IUserData
    {
        private readonly IMongoCollection<UserModel> _users;
        public MongoUserData(IDbconnection dbconnection)
        {
            _users = dbconnection.UserCollection;
        }

        //get all the users using async
        public async Task<List<UserModel>> GetUsersAsync()
        {
            var results = await _users.FindAsync(_ => true);
            return results.ToList();
        }


        //get a specific user by id
        public async Task<UserModel> GetUser(string id)
        {
            var result = await _users.FindAsync(x => x.Id == id);
            return result.FirstOrDefault();

        }

        public async Task<UserModel> GetUserFromAuthentication(string objectId)
        {
            var result = await _users.FindAsync(x => x.ObjectIdentifier == objectId);
            return result.FirstOrDefault();

        }
        //more like insert a user into database
        public Task CreateUser(UserModel user)
        {

            return _users.InsertOneAsync(user);

        }

        public Task UpdateUser(UserModel user)
        {
            var filter = Builders<UserModel>.Filter.Eq(field: "Id", user.Id);
            return _users.ReplaceOneAsync(filter, user, options: new ReplaceOptions { IsUpsert = true });

        }



    }
}
