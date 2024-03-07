
using BookStore.Services.DataTransferObjects.Requests;
using BookStore.Services.DataTransferObjects.Responses;

namespace BookStore.Services
{
    public interface IBookService
    {
        IEnumerable<BookDisplayResponse> GetBooksForDisplay(int? genreId = null);
        BookForAddToCard GetBookForAddToCard(int id);

        Task<IEnumerable<BookDisplayResponse>> GetBooksForDisplayAsync(int? genreId = null);
        Task<BookForAddToCard> GetBookForAddToCardAsync(int id);

        Task<int> CreateNewBook(CreateNewBookRequest createNewBookRequest);

        Task UpdateExistingBook(UpdateBookRequest updateBookRequest);
        Task DeleteAsync(int id);

        Task<UpdateBookRequest> GetBookForUpdateRequestAsync(int id);

    }
}