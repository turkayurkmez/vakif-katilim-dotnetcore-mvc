using BookStore.Common.Entities;
using BookStore.Infrastructure.DataAcess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.DataAcess.Repositories
{
    public class EFGenreRepository : IGenreRepository
    {

        private readonly BookStoreDbContext bookStoreDbContext;

        public EFGenreRepository(BookStoreDbContext bookStoreDbContext)
        {
            this.bookStoreDbContext = bookStoreDbContext;
        }

        public Task Create(Genre entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Genre Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Genre> GetAllWithEnumerable()
        {
            return bookStoreDbContext.Genres.ToList();
        }

        public async Task<IEnumerable<Genre>> GetAllWithEnumerableAsync()
        {
            return await bookStoreDbContext.Genres.ToListAsync();

        }

        public Task<Genre> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Genre entity)
        {
            throw new NotImplementedException();
        }
    }
}
