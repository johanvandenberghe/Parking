using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Services
{
    public class CarService : ICarService
    {
        private readonly IAsyncRepository<Car> _carRepository;

        public CarService(IAsyncRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task CreateCarAsync(string brand, decimal conso, decimal startConso)
        {
            var car = new Car(brand, conso, startConso);
            await _carRepository.AddAsync(car);
        }

        public async Task UpadteCarAsync(int carId, string brand, decimal conso, decimal startConso)
        {
            var car = await _carRepository.GetByIdAsync(carId);
            car.SetBrand(brand); 
            car.SetConso(conso); 
            car.SetStartConso(startConso);
            await _carRepository.AddAsync(car);
        }
    }
}
