using Microsoft.AspNetCore.Mvc;
using Site1.Data;

namespace Site1.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult List()
        {
            var kisiler = MockData.PersonList;


            return View(kisiler);
        }
    }
}
