using Automarket.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Automarket.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> Create(T entity);

        Task<T> Get(int id);

        Task<List<Car>> Select();

        Task<bool> Delete(T entity);
    }
}
