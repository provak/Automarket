﻿using Automarket.DAL.Interfaces;
using Automarket.Domain.Enums;
using Automarket.Domain.Models;
using Automarket.Domain.Response;
using Automarket.Domain.ViewModels.Car;
using Automarket.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Automarket.Service.Implementations
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IBaseResponse<Car>> GetCar(int id)
        {
            var baseResponse = new BaseResponse<Car>();

            try
            {
                var car = await _carRepository.Get(id);

                if (car == null)
                {
                    baseResponse.Description = "Car not found";
                    baseResponse.StatusCode = StatusCode.CarNotFound;
                    return baseResponse;
                }

                baseResponse.Data = car;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[GetCar]: {ex.Message}",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
        }

        public async Task<IBaseResponse<Car>> GetCarByName(string name)
        {
            var baseResponse = new BaseResponse<Car>();

            try
            {
                var car = await _carRepository.GetByName(name);

                if (car == null)
                {
                    baseResponse.Description = "Car not found";
                    baseResponse.StatusCode = StatusCode.CarNotFound;
                    return baseResponse;
                }

                baseResponse.Data = car;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[GetCarByName]: {ex.Message}",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
        }

        public async Task<IBaseResponse<CarViewModel>> CreateCar(CarViewModel carViewModel)
        {
            var baseResponse = new BaseResponse<CarViewModel>();
            try
            {
                var car = new Car()
                {
                    Description = carViewModel.Description,
                    DateCreated = carViewModel.DateCreated,
                    Speed = carViewModel.Speed,
                    Model = carViewModel.Model,
                    Price = carViewModel.Price,
                    Name = carViewModel.Name,
                    TypeCar = (TypeCar)Convert.ToInt32(carViewModel.TypeCar)
                };

                await _carRepository.Create(car);

                baseResponse.StatusCode = StatusCode.OK;
                baseResponse.Data = carViewModel;
            }
            catch (Exception ex)
            {
                return new BaseResponse<CarViewModel>()
                {
                    Description = $"[CreateCar]: {ex.Message}",
                    StatusCode = StatusCode.InternalServiceError
                };
            }

            return baseResponse;
        }

        public async Task<IBaseResponse<bool>> DeleteCar(int id)
        {
            var baseResponse = new BaseResponse<bool>();

            try
            {
                var car = await _carRepository.Get(id);

                if (car == null)
                {
                    baseResponse.Description = "Car not found";
                    baseResponse.StatusCode = StatusCode.CarNotFound;
                    return baseResponse;
                }

                await _carRepository.Delete(car);
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteCar]: {ex.Message}",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Car>>> GetCars()
        {
            var baseResponse = new BaseResponse<IEnumerable<Car>>();

            try
            {
                var cars = await _carRepository.Select();

                if (cars.Count == 0)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;

                    return baseResponse;
                }

                baseResponse.Data = cars;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Car>>()
                {
                    Description = $"[GetCars]: {ex.Message}",
                    StatusCode = StatusCode.InternalServiceError                    
                };
            }
        }
    }
}
