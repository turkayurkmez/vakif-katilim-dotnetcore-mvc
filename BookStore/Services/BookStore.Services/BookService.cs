using AutoMapper;
using BookStore.Common.Entities;
using BookStore.Infrastructure.DataAcess.Repositories;
using BookStore.Services.DataTransferObjects.Requests;
using BookStore.Services.DataTransferObjects.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            this.mapper = mapper;
        }

        public async Task<int> CreateNewBook(CreateNewBookRequest createNewBookRequest)
        {
            //var book = new Book
            //{
            //    Author = createNewBookRequest.Author,
            //    Description = createNewBookRequest.Description,
            //    DiscountRate = createNewBookRequest.DiscountRate,
            //    GenreId = createNewBookRequest.GenreId,
            //    ImageUrl = createNewBookRequest.ImageUrl,
            //    Price = createNewBookRequest.Price,
            //    Stock = createNewBookRequest.Stock,
            //    Title = createNewBookRequest.Title,
            //};

            var book = mapper.Map<Book>(createNewBookRequest);
            await _bookRepository.Create(book);

            return book.Id;
        }

        public async Task DeleteAsync(int id)
        {
            await _bookRepository.Delete(id);
        }

        public BookForAddToCard GetBookForAddToCard(int id)
        {
            var book = _bookRepository.Get(id);
            return mapper.Map<BookForAddToCard>(book);
        }

        public async Task<BookForAddToCard> GetBookForAddToCardAsync(int id)
        {
            var book = await _bookRepository.GetAsync(id);
            return mapper.Map<BookForAddToCard>(book);

        }

        public async Task<UpdateBookRequest> GetBookForUpdateRequestAsync(int id)
        {
            var book = await _bookRepository.GetAsync(id);
            return mapper.Map<UpdateBookRequest>(book);

        }

        public IEnumerable<BookDisplayResponse> GetBooksForDisplay(int? genreId = null)
        {

            var books = genreId == null ? _bookRepository.GetAllWithEnumerable() :
                                            _bookRepository.GetBooksByGenre(genreId.Value);
            var response = books.Select(b => new BookDisplayResponse
            {
                Author = b.Author,
                Description = b.Description,
                DiscountRate = b.DiscountRate,
                ImageUrl = b.ImageUrl,
                Id = b.Id,
                Price = b.Price,
                Title = b.Title
            });

            return response;
        }

        public async Task<IEnumerable<BookDisplayResponse>> GetBooksForDisplayAsync(int? genreId = null)
        {
            var books = genreId == null ? await _bookRepository.GetAllWithEnumerableAsync() :
                                          await _bookRepository.GetBooksByGenreAsync(genreId.Value);

            var response = books.Select(b => new BookDisplayResponse
            {
                Author = b.Author,
                Description = b.Description,
                DiscountRate = b.DiscountRate,
                ImageUrl = b.ImageUrl,
                Id = b.Id,
                Price = b.Price,
                Title = b.Title
            });

            return response;
        }

        public async Task UpdateExistingBook(UpdateBookRequest updateBookRequest)
        {
            var book = mapper.Map<Book>(updateBookRequest);
            await _bookRepository.Update(book);
        }
    }
}
