using BookStore.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.DataAcess.Repositories
{
    public class FakeGenreRepository : IGenreRepository
    {

        private List<Genre> _genreList = new List<Genre>
        {
             new(){ Id=1, Name="Bilim kurgu"},
             new(){ Id=2, Name="Edebiyat"},
             new(){ Id=3, Name="Felsefe"},


        };

        public Genre Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Genre> GetAllWithEnumerable()
        {
            return _genreList;
        }
    }
}
