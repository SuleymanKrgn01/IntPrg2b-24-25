using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CookSite.Models;

namespace CookSite.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        CookSiteContext db = new CookSiteContext();
        var cookTypes = db.CookTypes.ToList();
        ViewBag.CookTypes = cookTypes;
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

    public IActionResult Contact() {
        return View();
    }

}
