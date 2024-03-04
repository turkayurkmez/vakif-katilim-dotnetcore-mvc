using Microsoft.AspNetCore.Mvc;

namespace introduceDotNetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int? id = null)
        {
            ViewBag.Country = "Türkiye";
            ViewBag.Day = DateTime.Now.Day;
            return View();


        }
    }
}
