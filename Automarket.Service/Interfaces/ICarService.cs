using Automarket.Domain.Models;
using Automarket.Domain.Response;
using Automarket.Domain.ViewModels.Car;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Automarket.Service.Interfaces
{
    public interface ICarService
    {
        Task<IBaseResponse<Car>> GetCar(int id);
        Task<IBaseResponse<Car>> GetCarByName(string name);
        Task<IBaseResponse<CarViewModel>> CreateCar(CarViewModel carViewModel);
        Task<IBaseResponse<bool>> DeleteCar(int id);
        Task<IBaseResponse<IEnumerable<Car>>> GetCars();
    }
}
