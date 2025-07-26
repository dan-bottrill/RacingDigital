using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RacingDigital.Areas.Identity.Models;
using RacingDigital.Models;
using RacingDigital.Services;

namespace RacingDigital.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly RaceResultService _raceResultService;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _raceResultService = new RaceResultService();
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult RaceResults()
    {
        return View();
    }

    public IActionResult Analytics()
    {
        return View();
    }

    public IActionResult MyStable()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRaceResults()
    {
        var results = await _raceResultService.GetAllRacesWithNotesAsync();
        return Json(results);
    }


    public async Task<IActionResult> SeedTestUser(
    [FromServices] UserManager<AppUser> userManager)
    {
        var user = new AppUser
        {
            UserName = "RacehorseOwner123",
            FullName = "Dan Bottrill"
        };

        var result = await userManager.CreateAsync(user, "RedRum2025&");

        if (result.Succeeded)
            return Ok("User created!");
        else
            return BadRequest(result.Errors);
    }
}
