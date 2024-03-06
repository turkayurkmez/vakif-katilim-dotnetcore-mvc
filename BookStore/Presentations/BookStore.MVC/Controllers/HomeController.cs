using BookStore.Common.Entities;
using BookStore.MVC.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookStore.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookService bookService;

        public HomeController(ILogger<HomeController> logger, IBookService bookService)
        {
            this.bookService = bookService;
            _logger = logger;
        }

        public IActionResult Index(int page = 1, int? genre = null)
        {

            var books = bookService.GetBooksForDisplay(genre);
            var totalItems = books.Count();
            var pageSize = 10;
            var itemCountInARow = 6;
            var totalPages = (int)Math.Ceiling((decimal)totalItems / pageSize);

            /*
             *  page 1:
             *     0  ile 2 arasında
             *  page 2:
             *     2  ile 4 arasında          
             *  page 3:
             *     4 ile 6 arasında
             *  
             *     
             */

            int startPosition = (page - 1) * pageSize;
            int finalPosition = startPosition + pageSize;

            var paginatedBooks = books.OrderBy(p => p.Id)
                                      .Take(startPosition..finalPosition);

            ViewBag.ActivePage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.SelectedGenre = genre;
            ViewBag.ColumnSize = itemCountInARow;

            return View(paginatedBooks);
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
    }
}
