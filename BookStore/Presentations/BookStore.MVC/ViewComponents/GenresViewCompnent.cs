using BookStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.MVC.ViewComponents
{
    public class GenresViewComponent : ViewComponent
    {
        private readonly IGenreService genreService;

        public GenresViewComponent(IGenreService genreService)
        {
            this.genreService = genreService;
        }

        public IViewComponentResult Invoke()
        {
            var genres = genreService.GetAllGenresForMenu();
            return View(genres);
        }
    }
}
