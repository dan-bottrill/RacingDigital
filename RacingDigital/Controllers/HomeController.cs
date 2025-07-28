using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RacingDigital.Areas.Identity.Models;
using RacingDigital.Models;
using RacingDigital.Services;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RacingDigital.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly RaceResultService _raceResultService;
    private readonly MyStableService _myStableService;

    public HomeController(ILogger<HomeController> logger, RaceResultService raceResultService, MyStableService myStableService)
    {
        _logger = logger;
        _raceResultService = raceResultService;
        _myStableService = myStableService;
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

    [Authorize]
    public IActionResult MyStable()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
        {           
            return RedirectToAction("Login", "Identity");
        }

        var viewModel = _myStableService.GetHorseDetails(userId);
        return View(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRaceResults()
    {
        var results = await _raceResultService.GetAllRacesWithNotesAsync();
        return Json(results);
    }

}
