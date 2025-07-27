using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MongoDB.Driver;
using Mono.TextTemplating;
using RacingDigital.Models;

namespace RacingDigital.Services
{
    public class MyStableService
    {
        private readonly IMongoCollection<HorseProfile> _horseCollection;

        public MyStableService()
        {
            var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");

            if (string.IsNullOrEmpty(connectionString))
            {
                Console.WriteLine("Error: MongoDB connection string not found in environment variables.");
                Environment.Exit(0);
            }

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("RacingDigital");
            _horseCollection = database.GetCollection<HorseProfile>("HorseProfile");
        }
        public HorseProfile GetHorseDetails(string userId)
        {
            return _horseCollection.Find(h => h.UserId == userId).FirstOrDefault();
        }

        public async Task<bool> SaveDetails(HorseProfile model)
        {
            try
            {
                var filter = Builders<HorseProfile>.Filter.Eq(p => p.UserId, model.UserId);
                var existing = await _horseCollection.Find(filter).FirstOrDefaultAsync();

                if (existing != null)
                {                    
                    model._id = existing._id;

                    var result = await _horseCollection.ReplaceOneAsync(
                        filter,
                        model,
                        new ReplaceOptions { IsUpsert = false }
                    );

                    return result.IsAcknowledged && result.ModifiedCount > 0;
                }
                else
                {
                    await _horseCollection.InsertOneAsync(model);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving horse details: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> SetJockey(HorseProfile model)
        {
            try
            {
                var filter = Builders<HorseProfile>.Filter.Eq(p => p.UserId, model.UserId);
                var existing = await _horseCollection.Find(filter).FirstOrDefaultAsync();

                if (existing != null)
                {
                    existing.Jockey = model.Jockey;

                    var result = await _horseCollection.ReplaceOneAsync(
                        filter,
                        existing,
                        new ReplaceOptions { IsUpsert = false }
                    );

                    return result.IsAcknowledged && result.ModifiedCount > 0;
                }
                else
                {
                    await _horseCollection.InsertOneAsync(model);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving horse details: {ex.Message}");
                return false;
            }

        }
        }
    }
