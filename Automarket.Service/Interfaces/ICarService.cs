using Automarket.Domain.Models;
using Automarket.Domain.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Automarket.Service.Interfaces
{
    public interface ICarService
    {
        Task<IBaseResponse<IEnumerable<Car>>> GetCars();
    }
}
