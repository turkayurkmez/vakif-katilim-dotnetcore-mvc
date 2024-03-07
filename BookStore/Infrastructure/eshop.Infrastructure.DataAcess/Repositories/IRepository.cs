using BookStore.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.DataAcess.Repositories
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        IEnumerable<T> GetAllWithEnumerable();
        T Get(int id);

        Task<IEnumerable<T>> GetAllWithEnumerableAsync();
        Task<T> GetAsync(int id);

        Task Create(T entity);
        Task Update(T entity);
        Task Delete(int id);

        Task<bool> IsExistsAsync(int id);

    }
}
