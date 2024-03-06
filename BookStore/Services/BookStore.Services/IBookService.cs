
using BookStore.Services.DataTransferObjects.Responses;

namespace BookStore.Services
{
    public interface IBookService
    {
        IEnumerable<BookDisplayResponse> GetBooks(int? genreId = null);
    }
}