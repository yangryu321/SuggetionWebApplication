using MongoDB.Driver;
using SuggestionAppLibrary.Models;

namespace SuggestionAppLibrary.DataAccess
{
    public interface IDbconnection
    {
        IMongoCollection<CategoryModel> CategoryCollection { get; }
        string CategoryCollectionName { get; }
        MongoClient Client { get; }
        string DbName { get; }
        IMongoCollection<StatusModel> StatusCollection { get; }
        string StatusCollectionName { get; }
        IMongoCollection<SuggestionModel> SuggestionCollection { get; }
        string SuggetionCollectionName { get; }
        IMongoCollection<UserModel> UserCollection { get; }
        string UserCollectionName { get; }
    }
}
