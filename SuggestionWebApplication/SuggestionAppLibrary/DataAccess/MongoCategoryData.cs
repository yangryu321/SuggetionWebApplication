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
    public class MongoCategoryData : ICategoryData
    {

        private readonly IMongoCollection<CategoryModel> _categories;
        private readonly IMemoryCache _cache;
        private const string cacheName = "CategoryData";

        public MongoCategoryData(IDbconnection dbconnection, IMemoryCache cache)
        {
            _cache = cache;
            _categories = dbconnection.CategoryCollection;
        }


        public async Task<List<CategoryModel>> GetAllCategories()
        {
            //get data from cache
            var output = _cache.Get<List<CategoryModel>>(cacheName);

            //if data doesnt exist in cache then get it from database then put it in cache
            if (output == null)
            {
                var results = await _categories.FindAsync(_ => true);
                output = results.ToList();

                _cache.Set(cacheName, output, TimeSpan.FromDays(value: 1));
            }

            return output;
        }

        public Task CreateCategory(CategoryModel category)
        {

            return _categories.InsertOneAsync(category);

        }





    }
}
