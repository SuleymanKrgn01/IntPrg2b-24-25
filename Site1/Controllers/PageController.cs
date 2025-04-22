using Microsoft.AspNetCore.Mvc;

namespace Site1.Controllers
{
    public class PageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Page1()
        {

            ViewData["sayi"] = new Random().Next(60, 90);
            ViewData["kelime"] = "Merhaba";

            ViewBag.sayi2= new Random().Next(20,40);

            return View();

        }



        public IActionResult Page2() {

            return View();
        }


    }
}
