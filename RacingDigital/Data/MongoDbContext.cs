using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbGenericRepository;

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

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }

        public void SetGuidRepresentation(GuidRepresentation guidRepresentation)
        {
            throw new NotImplementedException();
        }
    }
}
