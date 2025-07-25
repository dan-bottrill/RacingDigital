using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using RacingDigital.Models;

namespace RacingDigital.Services
{
    public class RaceResultService
    {

        private readonly IMongoCollection<RaceResult> _raceResultsCollection;
        private readonly IMongoCollection<RaceNotes> _notesCollection;

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
            _raceResultsCollection = database.GetCollection<RaceResult>("Races");
            _notesCollection = database.GetCollection<RaceNotes>("Notes");            
        }

        public List<RaceResult> GetAllRaces()
        {
            return _raceResultsCollection.Find(r => true).ToList();
        }

        public async Task<List<RaceResultWithNote>> GetAllRacesWithNotesAsync()
        {
            var races = await _raceResultsCollection.Find(_ => true).ToListAsync();
            var notes = await _notesCollection.Find(_ => true).ToListAsync();

            var result = races.Select(race =>
            {
                var note = notes.FirstOrDefault(n => n.RaceId == race._id);

                return new RaceResultWithNote
                {
                    _id = race._id,
                    Race = race.Race,
                    RaceDate = race.RaceDate,
                    RaceTime = race.RaceTime,
                    Racecourse = race.Racecourse,
                    RaceDistance = race.RaceDistance,
                    Jockey = race.Jockey,
                    Trainer = race.Trainer,
                    Horse = race.Horse,
                    FinishingPosition = race.FinishingPosition,
                    DistanceBeaten = race.DistanceBeaten,
                    TimeBeaten = race.TimeBeaten,
                    Notes = note?.Note
                };
            }).ToList();

            return result;
        }

        public RaceResult GetRaceById(object id)
        {
            return _raceResultsCollection.Find(r => r._id == id).FirstOrDefault();
        }

        public void UpdateRaceResult(string id, RaceResult raceResult)
        {
            _raceResultsCollection.ReplaceOne(race => race._id == id, raceResult);
        }

        public async Task<bool> SaveNoteAsync(RaceNotes note)
        {
            if (string.IsNullOrWhiteSpace(note.Note) || string.IsNullOrEmpty(note.RaceId))
                return false;

            await _notesCollection.InsertOneAsync(note);
            return true;
        }

    }
}
