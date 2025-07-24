using MongoDB.Driver;
using RacingDigital.Areas.Identity.Models;

namespace RacingDigital.Services
{
    public class SartupService
    {

        private readonly IMongoCollection<AppUser> _usersCollection;

        public SartupService(IMongoClient client)
        {
            var database = client.GetDatabase("RacingDigital");
            _usersCollection = database.GetCollection<AppUser>("Users");
        }

        public void InsertTestUser()
        {
            // Check if user already exists
            var existingUser = _usersCollection.Find(u => u.UserName == "testuser").FirstOrDefault();
            if (existingUser == null)
            {
                // Create a test user
                var testUser = new AppUser
                {
                    UserName = "RacehorseOwner123",
                    FullName = "Dan Bottrill",
                    Password = "RedRum2025&",
                };

                // Insert the test user
                _usersCollection.InsertOne(testUser);
                Console.WriteLine("Test user inserted.");
            }
            else
            {
                Console.WriteLine("Test user already exists.");
            }
        }

    }
}
