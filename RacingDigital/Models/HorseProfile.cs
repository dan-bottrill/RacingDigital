using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace RacingDigital.Models
{
    public class HorseProfile
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string HorseName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FoaledDate { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Races run must be a non-negative number.")]
        public int RacesRun { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Races won must be a non-negative number.")]
        public int RacesWon { get; set; }

        [Required]
        public string Trainer { get; set; }

        public string Jockey { get; set; }

        public string Notes { get; set; }
    }
}
