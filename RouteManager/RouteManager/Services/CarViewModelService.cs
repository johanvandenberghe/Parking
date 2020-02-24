using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using RouteManager.Interfaces;
using RouteManager.ViewModels;

namespace RouteManager.Services
{
    public class CarViewModelService : ICarViewModelService
    {
        private readonly IAsyncRepository<Car> _carRepository;

        public CarViewModelService(IAsyncRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IEnumerable<CarViewModel>> GetAllcarAsync()
        {
            var cars = await _carRepository.ListAllAsync();
            var carsVm = new List<CarViewModel>();
            foreach (var car in cars)
            {
                carsVm.Add(CreateViewModelFromCar(car));
            }

            return carsVm;
        }

        public async Task<CarViewModel> GetCarAsync(int carId)
        {
            var car = await _carRepository.GetByIdAsync(carId);
            return CreateViewModelFromCar(car);
        }

        private CarViewModel CreateViewModelFromCar(Car car)
        {
            var viewModel = new CarViewModel
            {
                Id = car.Id,
                Brand = car.Brand,
                Conso = car.Conso,
                StartConso = car.StartConso
            };

            return viewModel;
        }
    }
}