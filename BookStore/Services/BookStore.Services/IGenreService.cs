using BookStore.Common.Entities;

namespace BookStore.Services
{
    public interface IGenreService
    {
        IEnumerable<Genre> GetAllGenresForMenu();
    }
}