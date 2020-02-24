using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using GeoCoordinatePortable;
using Microsoft.AspNetCore.Mvc.Rendering;
using RouteManager.Interfaces;
using RouteManager.ViewModels;

namespace RouteManager.Services
{
    public class RouteViewModelService : IRouteViewModelService
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IAsyncRepository<Parking> _parkingRepository;
        private readonly IAsyncRepository<Car> _carRepository;

        public RouteViewModelService(IRouteRepository routeRepository, IAsyncRepository<Parking> parkingRepository, IAsyncRepository<Car> carRepository)
        {
            _routeRepository = routeRepository;
            _parkingRepository = parkingRepository;
            _carRepository = carRepository;
        }

        public async Task<IEnumerable<RouteViewModel>> GetAllRouteAsync()
        {
            var routes = await _routeRepository.GetAllWithParkingsAndCarAsync();
            var routesVm = new List<RouteViewModel>();
            foreach (var route in routes)
            {
                routesVm.Add(CreateViewModelFromParking(route));
            }

            return routesVm;
        }

        public async Task<EditRouteViewModel> GetRouteEditAsync(int? routeId)
        {
            var parkings = await _parkingRepository.ListAllAsync();
            var cars = await _carRepository.ListAllAsync();
            var route = routeId != null ? await _routeRepository.GetByIdAsync(routeId.Value) : await Task.FromResult<Route>(null);
            
            return CreateEditViewModelFromParking(route, parkings, cars);
        }
        
        private RouteViewModel CreateViewModelFromParking(Route route)
        {
            var viewModel = new RouteViewModel();
            viewModel.Id = route.Id;
            viewModel.Name = route.Name;
            viewModel.DepartureParking = new ParkingViewModel{Id =  route.DepartureParking.Id, Name = route.DepartureParking.Name, Position = new GeoCoordinate(route.DepartureParking.CoordX, route.DepartureParking.CoordY)};
            viewModel.ArrivalParking = new ParkingViewModel { Id = route.ArrivalParking.Id, Name = route.ArrivalParking.Name, Position = new GeoCoordinate(route.ArrivalParking.CoordX, route.ArrivalParking.CoordY)};
            viewModel.Car = new CarViewModel { Brand = route.Car.Brand, Id = route.Car.Id, Conso = route.Car.Conso, StartConso = route.Car.StartConso};

            return viewModel;
        }

        private EditRouteViewModel CreateEditViewModelFromParking(Route route, IEnumerable<Parking> parkings, IEnumerable<Car> cars)
        {
            var viewModel = new EditRouteViewModel();

            if (route != null)
            {
                viewModel.RouteId = route.Id;
                viewModel.DepartureParkingId = route.DepartureParkingId;
                viewModel.ArrivalParkingId = route.ArrivalParkingId;
                viewModel.CarId = route.CarId;
                viewModel.Name = route.Name;
            }
            viewModel.Cars = cars.Select(c => new SelectListItem() {Text = c.Brand, Value = c.Id.ToString(), Selected = route != null && c.Id == route.CarId}).ToList();
            viewModel.DepartureParkings = parkings.Select(c => new SelectListItem() {Text = c.Name, Value = c.Id.ToString(), Selected = route != null && c.Id == route.DepartureParkingId}).ToList();
            viewModel.DestinationParkings = parkings.Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString(), Selected = route != null && c.Id == route.ArrivalParkingId }).ToList();

            return viewModel;
        }
    }
}