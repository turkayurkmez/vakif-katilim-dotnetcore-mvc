using BookStore.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.DataAcess.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        IEnumerable<Book> Search(string name);
        IEnumerable<Book> GetBooksByGenre(int genreId);

        Task<IEnumerable<Book>> SearchAsync(string name);
        Task<IEnumerable<Book>> GetBooksByGenreAsync(int genreId);

    }
}
