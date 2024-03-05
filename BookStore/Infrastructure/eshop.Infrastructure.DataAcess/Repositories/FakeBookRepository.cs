using BookStore.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.DataAcess.Repositories
{
    public class FakeBookRepository : IBookRepository
    {
        private List<Book> books = new List<Book>()
            {
                new(){ Id=1, Title = "Kırmızı Karma", Author="Christopher Grange", Description="Gerilim", Price=100, DiscountRate=0.05m},
                new(){ Id=2, Title = "Kitap 2", Author="Yazar 1", Description="Açıklama 1", Price=150, DiscountRate=0.05m},
                new(){ Id=3, Title = "Kitap 3", Author="Yazar 3", Description="Açıklama 3", Price=120, DiscountRate=0.05m},
                new(){ Id=4, Title = "Kitap 4", Author="Yazar 4", Description="Açıklama 4", Price=170, DiscountRate=0.05m},


            };
        public IEnumerable<Book> GetAllWithEnumerable()
        {
            return books;
        }

        public IEnumerable<Book> Search(string name)
        {
            throw new NotImplementedException();
        }
    }
}
