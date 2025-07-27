using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using RacingDigital.Models;
using RacingDigital.Services;
using System.Security.Claims;

namespace RacingDigital.Controllers
{
    public class MyStableController : Controller
    {
        private readonly MyStableService _myStableService;

        public MyStableController(MyStableService myStableService)
        {
            _myStableService = myStableService;
        }

        [HttpPost]
        public async Task<IActionResult> SaveHorseDetails(HorseProfile model)
        {
            if(ModelState == null)
            {
                return BadRequest("Invalid input");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(userId != null)
            {
                model.UserId = userId;
                var success = await _myStableService.SaveDetails(model);

                if (success)
                    return RedirectToAction("MyStable", "Home");

                return BadRequest("Failed to save note");
            }

            return BadRequest("User could not be found");
            
        }
    }
}
