using Microsoft.AspNetCore.Mvc;
using RacingDigital.Models;
using RacingDigital.Services;

namespace RacingDigital.Controllers
{
    public class RaceResultController : Controller
    {
        private readonly RaceResultService _raceResultService;

        public RaceResultController(RaceResultService raceResultService)
        {
            _raceResultService = raceResultService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveNote([FromBody] RaceNotes note)
        {
            if (note == null || string.IsNullOrWhiteSpace(note.Note) || string.IsNullOrWhiteSpace(note.RaceId))
            {
                return BadRequest("Invalid input");
            }

            var success = await _raceResultService.SaveNoteAsync(note);

            if (success)
                return Ok("Note saved");

            return BadRequest("Failed to save note");
        }
    }
}
