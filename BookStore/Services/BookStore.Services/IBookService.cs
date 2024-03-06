
using BookStore.Services.DataTransferObjects.Responses;

namespace BookStore.Services
{
    public interface IBookService
    {
        IEnumerable<BookDisplayResponse> GetBooksForDisplay(int? genreId = null);
        BookForAddToCard GetBookForAddToCard(int id);
    }
}