using CookSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CookSite.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            var db = new CookSiteContext();
            var liste = db.Users.ToList();
            return View(liste);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(User data)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Girilen veriler hatalıdır !");
                }
                var db = new CookSiteContext();
                db.Users.Add(data);
                db.SaveChanges();
                //return View();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

        }





    }
}
