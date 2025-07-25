using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RacingDigital.Models
{
    public class RaceNotes
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string RaceId { get; set; }
        public string Note { get; set; }
    }
}
