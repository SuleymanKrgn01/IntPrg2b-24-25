using Microsoft.AspNetCore.Mvc;

namespace Site1.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Hobies()
        {
            return View();
        }
        public IActionResult Abilities()
        {
            return View();
        }
        public IActionResult Education()
        {
            return View();
        }
    }
}
