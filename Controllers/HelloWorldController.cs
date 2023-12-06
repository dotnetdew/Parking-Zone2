using Microsoft.AspNetCore.Mvc;

namespace Parking_Zone.Controllers;

public class HelloWorldController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}