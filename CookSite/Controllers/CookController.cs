using CookSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CookSite.Controllers
{
    public class CookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int numara) {
            ViewBag.GelenNumara = numara;
            return View();
        }

        public IActionResult Detail(string ad)
        {
            ViewBag.GelenNumara = ad;
            return View();
        }

        public IActionResult Detail2(string tip, int no) {
            ViewBag.Tip= tip;
            ViewBag.No = no;
            return View(  "Detail"  );
        }

        public IActionResult CookTypeList() {
            CookSiteContext db = new();
            var liste = db.CookTypes.ToList();
            return View(liste);
        }

        public IActionResult AddCookType() {
            return View();
        }



    }
}
