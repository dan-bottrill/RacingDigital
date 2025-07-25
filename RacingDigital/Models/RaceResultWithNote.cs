namespace RacingDigital.Models
{
    public class RaceResultWithNote
    {
        public string _id { get; set; }
        public string Race { get; set; }
        public string RaceDate { get; set; }
        public int RaceTime { get; set; }
        public string Racecourse { get; set; }
        public int RaceDistance { get; set; }
        public string Jockey { get; set; }
        public string Trainer { get; set; }
        public string Horse { get; set; }
        public int FinishingPosition { get; set; }
        public double DistanceBeaten { get; set; }
        public double TimeBeaten { get; set; }

        public string? Notes { get; set; }
    }
}
