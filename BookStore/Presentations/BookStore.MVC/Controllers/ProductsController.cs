using BookStore.Services;
using BookStore.Services.DataTransferObjects.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;

namespace BookStore.MVC.Controllers
{
    [Authorize(Roles = "Admin,Editor")]
    public class ProductsController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IGenreService genreService;

        public ProductsController(IBookService bookService, IGenreService genreService)
        {
            _bookService = bookService;
            this.genreService = genreService;
        }

        //[AllowAnonymous]
        public async Task<IActionResult> Index()
        {

            var books = await _bookService.GetBooksForDisplayAsync();
            return View(books);
        }

        public IActionResult Create()
        {
            ViewBag.Genres = getGenresForSelect();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateNewBookRequest newBookRequest)
        {
            if (ModelState.IsValid)
            {
                await _bookService.CreateNewBook(newBookRequest);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Genres = getGenresForSelect();
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {

            ViewBag.Genres = getGenresForSelect();
            var updateRequest = await _bookService.GetBookForUpdateRequestAsync(id);
            return View(updateRequest);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateBookRequest updateBookRequest)
        {
            if (ModelState.IsValid)
            {
                await _bookService.UpdateExistingBook(updateBookRequest);
                return RedirectToAction(nameof(Index));

            }
            ViewBag.Genres = getGenresForSelect();
            return View(updateBookRequest);
        }

        private IEnumerable<SelectListItem> getGenresForSelect()
        {
            var genres = genreService.GetAllGenresForMenu();
            return genres.Select(g => new SelectListItem { Text = g.Name, Value = g.Id.ToString() });
        }
    }
}
