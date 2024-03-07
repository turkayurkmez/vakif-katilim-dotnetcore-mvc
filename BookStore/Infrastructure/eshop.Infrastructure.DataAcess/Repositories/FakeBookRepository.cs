//using BookStore.Common.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BookStore.Infrastructure.DataAcess.Repositories
//{
//    public class FakeBookRepository : IBookRepository
//    {
//        private List<Book> books = new List<Book>()
//            {
//                new(){ Id=1, Title = "Kırmızı Karma", Author="Christopher Grange", Description="Gerilim", Price=100, DiscountRate=0.05m, GenreId=1},
//                new(){ Id=2, Title = "Kitap 2", Author="Yazar 1", Description="Açıklama 1", Price=150, DiscountRate=0.05m, GenreId=2},
//                new(){ Id=3, Title = "Kitap 3", Author="Yazar 3", Description="Açıklama 3", Price=120, DiscountRate=0.05m, GenreId=3},
//                new(){ Id=4, Title = "Kitap 4", Author="Yazar 4", Description="Açıklama 4", Price=170, DiscountRate=0.05m, GenreId=1},
//                   new(){ Id=11, Title = "Kitap 11", Author="Christopher Grange", Description="Gerilim", Price=100, DiscountRate=0.05m, GenreId=1},
//                new(){ Id=5, Title = "Kitap 5", Author="Yazar 1", Description="Açıklama 1", Price=150, DiscountRate=0.05m, GenreId=2},
//                new(){ Id=6, Title = "Kitap 6", Author="Yazar 3", Description="Açıklama 3", Price=120, DiscountRate=0.05m, GenreId=3},
//                new(){ Id=7, Title = "Kitap 7", Author="Yazar 4", Description="Açıklama 4", Price=170, DiscountRate=0.05m, GenreId=1},
//                   new(){ Id=12, Title = "Kitap 12", Author="Christopher Grange", Description="Gerilim", Price=100, DiscountRate=0.05m, GenreId=1},
//                new(){ Id=8, Title = "Kitap 8", Author="Yazar 1", Description="Açıklama 1", Price=150, DiscountRate=0.05m, GenreId=2},
//                new(){ Id=9, Title = "Kitap 9", Author="Yazar 3", Description="Açıklama 3", Price=120, DiscountRate=0.05m, GenreId=3},
//                new(){ Id=10, Title = "Kitap 10", Author="Yazar 4", Description="Açıklama 4", Price=170, DiscountRate=0.05m, GenreId=1},

//            };

//        public Book Get(int id)
//        {
//            return books.SingleOrDefault(b => b.Id == id);
//        }

//        public IEnumerable<Book> GetAllWithEnumerable()
//        {
//            return books;
//        }

//        public IEnumerable<Book> GetBooksByGenre(int genreId)
//        {
//            return books.Where(b => b.GenreId == genreId);
//        }

//        public IEnumerable<Book> Search(string name)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
