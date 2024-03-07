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
    public class EFBookRepository : IBookRepository
    {

        private readonly BookStoreDbContext dbContext;

        public EFBookRepository(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Create(Book entity)
        {
            entity.CreatedDate = DateTime.Now;
            await dbContext.Books.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var deletingBook = await dbContext.Books.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
            dbContext.Books.Remove(deletingBook);


        }

        public Book Get(int id)
        {
            return dbContext.Books.AsNoTracking().SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Book> GetAllWithEnumerable()
        {
            return dbContext.Books.AsNoTracking().ToList();
        }

        public async Task<IEnumerable<Book>> GetAllWithEnumerableAsync()
        {
            return await dbContext.Books.ToListAsync();
        }

        public async Task<Book> GetAsync(int id)
        {
            return await dbContext.Books.AsNoTracking().SingleOrDefaultAsync(b => b.Id == id);
        }

        public IEnumerable<Book> GetBooksByGenre(int genreId)
        {
            return dbContext.Books.Where(b => b.GenreId == genreId).ToList();
        }

        public async Task<IEnumerable<Book>> GetBooksByGenreAsync(int genreId)
        {
            return await dbContext.Books.Where(b => b.GenreId == genreId).ToListAsync();
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await dbContext.Books.AnyAsync(b => b.Id == id);
        }

        public IEnumerable<Book> Search(string name)
        {
            return dbContext.Books.Where(b => b.Title.Contains(name)).ToList();
        }

        public async Task<IEnumerable<Book>> SearchAsync(string name)
        {
            return await dbContext.Books.Where(b => b.Title.Contains(name)).ToListAsync();

        }

        public async Task Update(Book entity)
        {
            entity.UpdatedDate = DateTime.Now;
            dbContext.Books.Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
