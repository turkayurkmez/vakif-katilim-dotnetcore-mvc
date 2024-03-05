using BookStore.Common.Entities;
using BookStore.Infrastructure.DataAcess.Repositories;
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

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<BookDisplayResponse> GetBooks()
        {

            var books = _bookRepository.GetAllWithEnumerable();
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

    }
}
