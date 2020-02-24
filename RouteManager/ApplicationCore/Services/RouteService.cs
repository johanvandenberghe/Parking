using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Ardalis.GuardClauses;

namespace ApplicationCore.Services
{
    public class RouteService : IRouteService
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IAsyncRepository<Car> _carRepository;
        private readonly IAsyncRepository<Parking> _parkingRepository;

        public RouteService(IRouteRepository routeRepository, IAsyncRepository<Parking> parkingRepository, IAsyncRepository<Car> carRepository)
        {
            _routeRepository = routeRepository;
            _parkingRepository = parkingRepository;
            _carRepository = carRepository;
        }

        public async Task CreateRouteAsync(string name, int carId, int departureParkingId, int arrivalParkingId)
        {
            var car = await _carRepository.GetByIdAsync(carId);
            Guard.Against.Null(car, nameof(car));

            var departure = await _parkingRepository.GetByIdAsync(departureParkingId);
            Guard.Against.Null(departure, nameof(departure));

            var destination = await _parkingRepository.GetByIdAsync(arrivalParkingId);
            Guard.Against.Null(destination, nameof(destination));

            var route = new Route(name, car, departure, destination);
            await _routeRepository.AddAsync(route);
        }

        public async Task UpadeRouteAsync(int routeId, string name, int carId, int departureParkingId, int arrivalParkingId)
        {
            var car = await _carRepository.GetByIdAsync(carId);
            Guard.Against.Null(car, nameof(car));

            var departure = await _parkingRepository.GetByIdAsync(departureParkingId);
            Guard.Against.Null(departure, nameof(departure));

            var destination = await _parkingRepository.GetByIdAsync(arrivalParkingId);
            Guard.Against.Null(destination, nameof(destination));

            var route = await _routeRepository.GetByIdAsync(routeId);
            Guard.Against.Null(destination, nameof(destination));

            route.SetName(name);
            route.SetCar(car);
            route.SetDeparture(departure);
            route.SetDestination(destination);

            await _routeRepository.UpdateAsync(route);
        }

        public async Task DeleteRouteAsync(int routeId)
        {
            var route = await _routeRepository.GetByIdAsync(routeId);
            Guard.Against.Null(route, nameof(route));

            await _routeRepository.DeleteAsync(route);
        }

        public async Task SetDestination(int routeId, int parkingId)
        {
            var route = await _routeRepository.GetByIdAsync(routeId);
            Guard.Against.Null(route, nameof(route));

            var parking = await _parkingRepository.GetByIdAsync(routeId);
            Guard.Against.Null(parking, nameof(parking));

            route.SetDestination(parking);
            await _routeRepository.UpdateAsync(route);
        }

        public async Task SetDeparture(int routeId, int parkingId)
        {
            var route = await _routeRepository.GetByIdAsync(routeId);
            Guard.Against.Null(route, nameof(route));

            var parking = await _parkingRepository.GetByIdAsync(routeId);
            Guard.Against.Null(route, nameof(route));

            route.SetDeparture(parking);
            await _routeRepository.UpdateAsync(route);
        }

        public async Task SetCar(int routeId, int carId)
        {
            var route = await _routeRepository.GetByIdAsync(routeId);
            Guard.Against.Null(route, nameof(route));

            var car = await _carRepository.GetByIdAsync(carId);
            Guard.Against.Null(car, nameof(car));

            route.SetCar(car);
            await _routeRepository.UpdateAsync(route);
        }
    }
}
