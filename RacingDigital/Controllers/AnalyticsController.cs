using Microsoft.AspNetCore.Mvc;
using RacingDigital.Models;
using RacingDigital.Services;

namespace RacingDigital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
        private readonly RaceResultService _raceService;

        public AnalyticsController(RaceResultService raceService)
        {
            _raceService = raceService;
        }

        [HttpGet("GetJockeyAnalytics")]
        public IActionResult GetJockeyAnalytics()
        {
            var allRaces = _raceService.GetAllRaces();

            // Need to filter data to retrieve unique dates to correctly identify in-form jockey
            var latest5Dates = allRaces
                .Select(r => r.RaceDate)
                .Distinct()
                .OrderByDescending(date => date)
                .Take(5)
                .ToList();


            var recentRaces = allRaces
                .Where(r => latest5Dates.Contains(r.RaceDate))
                .ToList();

            var result = new JockeyAnalyticsResults
            {
                BestOverallJockey = allRaces
    .GroupBy(r => r.Jockey)
    .Where(g => g.Count() >= 3)
    .OrderBy(g => g.Average(r => r.FinishingPosition))
    .Select(g => g.Key)
    .FirstOrDefault(),


                MostInFormJockey = recentRaces
    .GroupBy(r => r.Jockey)
    .Where(g => g.Count() >= 2)
    .OrderBy(g => g.Average(r => r.FinishingPosition))
    .Select(g => g.Key)
    .FirstOrDefault(),

                BestShortDistanceJockey = allRaces
    .Where(r => r.RaceDistance <= 1915)
    .GroupBy(r => r.Jockey)
    .Where(g => g.Count() >= 3)
    .OrderBy(g => g.Average(r => r.FinishingPosition))
    .Select(g => g.Key)
    .FirstOrDefault(),

                BestLongDistanceJockey = allRaces
    .Where(r => r.RaceDistance > 1915)
    .GroupBy(r => r.Jockey)
    .Where(g => g.Count() >= 3)
    .OrderBy(g => g.Average(r => r.FinishingPosition))
    .Select(g => g.Key)
    .FirstOrDefault(),

                BestEarlyPerformer = allRaces
    .Where(r => r.RaceTime < 1623)
    .GroupBy(r => r.Jockey)
    .Where(g => g.Count() >= 3)
    .OrderBy(g => g.Average(r => r.FinishingPosition))
    .Select(g => g.Key)
    .FirstOrDefault(),

                BestLatePerformer = allRaces
    .Where(r => r.RaceTime >= 1623)
    .GroupBy(r => r.Jockey)
    .Where(g => g.Count() >= 3)
    .OrderBy(g => g.Average(r => r.FinishingPosition))
    .Select(g => g.Key)
    .FirstOrDefault()
            };

            return Ok(result);
        }

        [HttpGet("GetAllRacecourses")]
        public IActionResult GetAllRacecourses()
        {
            var courses = _raceService.GetAllRaces()
                .Select(r => r.Racecourse)
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            return Ok(courses);
        }

        [HttpGet("GetAllTrainers")]
        public IActionResult GetAllTrainers()
        {
            var trainers = _raceService.GetAllRaces()
                .Select(r => r.Trainer)
                .Distinct()
                .OrderBy(t => t)
                .ToList();

            return Ok(trainers);
        }

        [HttpGet("GetBestByRacecourse")]
        public IActionResult GetBestByRacecourse(string course)
        {
            var races = _raceService.GetAllRaces().Where(r => r.Racecourse == course);

            var result = races.GroupBy(r => r.Jockey).OrderBy(g => g.Average(r => r.FinishingPosition)).Select(g => g.Key).Take(3);

            return Ok(result);
        }

        [HttpGet("GetBestByTrainer")]
        public IActionResult GetBestByTrainer(string trainer)
        {
            var races = _raceService.GetAllRaces().Where(r => r.Trainer == trainer);

            var result = races.GroupBy(r => r.Jockey).OrderBy(g => g.Average(r => r.FinishingPosition)).Select(g => g.Key).Take(3);

            return Ok(result);
        }
    }
}
