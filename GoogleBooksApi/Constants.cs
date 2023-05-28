using MongoDB.Bson;
using MongoDB.Driver;

namespace GoogleBooksApi
{
    internal class Constants
    {
        public static string ApiKey = "xxxxxxx";
        public static string Address = "xxxxxx";
        public static MongoClient mongoClient;
        public static IMongoDatabase database;
        public static IMongoCollection<BsonDocument> collection;
    }
}
