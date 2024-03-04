using introduceDotNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace introduceDotNetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int? id = null)
        {
            ViewBag.Country = "Türkiye";
            ViewBag.Day = DateTime.Now.Day;

            var list = new List<Country>()
            {
                new(){ Id=1, Name="Türkiye"},
                new(){ Id=2, Name="Arjantin"},
                new(){ Id=3, Name="Makedonya"},
                new(){ Id=4, Name="Yunanistan"}

            };


            //ViewBag.Countries = list;

            return View(list);


        }

        public IActionResult Show()
        {
            var countries = new List<Country>()
            {
                new(){ Id=1, Name="Türkiye"},
                new(){ Id=2, Name="Arjantin"},
                new(){ Id=3, Name="Makedonya"},
                new(){ Id=4, Name="Yunanistan"}

            };


            var companies = new List<Company>()
            {
                new(){ Id=1, Name ="Arçelik" },
                new(){ Id=2, Name ="Ülker" },
            };

            var viewModel = new ShowViewModel() { Companies = companies, Countries = countries };

            return View(viewModel);

        }

        public IActionResult Invite()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Invite(UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                ViewBag.HotReload = "Action";
                return View("Thanks", userInfo);
            }
            return View();
        }

    }
}
