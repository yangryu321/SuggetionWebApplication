using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using MongoDB.Driver;
using SuggestionAppLibrary.Models;

namespace SuggestionAppLibrary.DataAccess
{
    public class MongoStatusData : IStatusData
    {
        private readonly IMongoCollection<StatusModel> _statuses;
        private readonly IMemoryCache _cache;
        private const string cacheName = "StatusData";
        public MongoStatusData(IDbconnection dbconnection, IMemoryCache cache)
        {
            _statuses = dbconnection.StatusCollection;
            _cache = cache;

        }

        public async Task<List<StatusModel>> GetAllStatuses()
        {

            var output = _cache.Get<List<StatusModel>>(cacheName);

            if (output == null)
            {
                var result = await _statuses.FindAsync(_ => true);
                output = result.ToList();

                _cache.Set(cacheName, output, TimeSpan.FromDays(value: 1));

            }

            return output;
        }


        public Task CreateStatus(StatusModel status)
        {
            return _statuses.InsertOneAsync(status);
        }


    }
}
