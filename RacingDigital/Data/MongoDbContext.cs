using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbGenericRepository;
using MongoDbGenericRepository.Attributes;

namespace RacingDigital.Data
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoClient Client => throw new NotImplementedException();

        public IMongoDatabase Database => throw new NotImplementedException();

        public void DropCollection<TDocument>(string partitionKey = null)
        {
            throw new NotImplementedException();
        }

        private static string ResolveCollectionName<T>()
        {
            var attr = typeof(T).GetCustomAttributes(typeof(CollectionNameAttribute), true)
                                .FirstOrDefault() as CollectionNameAttribute;
            return attr?.Name ?? typeof(T).Name;
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName = null)
        {
            var name = collectionName ?? ResolveCollectionName<T>();
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Collection name is required");

            return _database.GetCollection<T>(name);
        }

        public void SetGuidRepresentation(GuidRepresentation guidRepresentation)
        {
            throw new NotImplementedException();
        }
    }
}
