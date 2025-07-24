using Microsoft.AspNetCore.Mvc;

namespace RacingDigital.Controllers
{
    public class CRUDController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
