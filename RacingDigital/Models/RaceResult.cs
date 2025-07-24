using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace RacingDigital.Models
{
    public class RaceResult
    {
        [BsonId]
        public object _id { get; set; }
        public string Race { get; set; }
        public string RaceDate { get; set; }
        public int RaceTime { get; set; }

        public string Racecourse { get; set; }

        public int RaceDistance { get; set; }

        public string Jockey { get; set; }

        public string Trainer { get; set; }

        public string Horse { get; set; }

        public int FinishingPosition { get; set; }

        public int DistanceBeaten { get; set; }

        public int TimeBeaten { get; set; }

        public string Notes { get; set; }
    }
}
