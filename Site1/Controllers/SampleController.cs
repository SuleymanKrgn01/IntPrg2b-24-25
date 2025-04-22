using Microsoft.AspNetCore.Mvc;

namespace Site1.Controllers
{
    public class SampleController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult OddEven()
        {
            var sayi = new Random().Next(1, 50);
            if (sayi % 2 == 0)
            {
                return View("Even");
            }
            else
            {
                return View("Odd");
            }
        }
    }
}
