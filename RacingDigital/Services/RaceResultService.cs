using MongoDB.Driver;
using RacingDigital.Models;

namespace RacingDigital.Services
{
    public class RaceResultService
    {

        private readonly IMongoCollection<RaceResult> _raceResultsCollection;

        public RaceResultService()
        {
            // Fetch string from global env variable
            var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");

            if (string.IsNullOrEmpty(connectionString))
            {
                Console.WriteLine("Error: MongoDB connection string not found in environment variables.");
                Environment.Exit(0);  // Exit if connection string not found
            }

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("RacingDigital");
            _raceResultsCollection = database.GetCollection<RaceResult>("RaceResults");
        }

        public List<RaceResult> GetAllRaces()
        {
            return _raceResultsCollection.Find(r => true).ToList();
        }

        public RaceResult GetRaceById(object id)
        {
            return _raceResultsCollection.Find(r => r._id == id).FirstOrDefault();
        }

        public void UpdateRaceResult(string id, RaceResult raceResult)
        {
            _raceResultsCollection.ReplaceOne(race => race._id == id, raceResult);
        }
    }
}
