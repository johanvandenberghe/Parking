using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using GeoCoordinatePortable;
using RouteManager.Interfaces;
using RouteManager.ViewModels;

namespace RouteManager.Services
{
    public class ParkingViewModelService : IParkingViewModelService
    {
        private readonly IAsyncRepository<Parking> _parkingRepository;

        public ParkingViewModelService(IAsyncRepository<Parking> parkingRepository)
        {
            _parkingRepository = parkingRepository;
        }

        public async Task<IEnumerable<ParkingViewModel>> GetAllParkingAsync()
        {
            var parkings = await _parkingRepository.ListAllAsync();
            var parkingsVm = new List<ParkingViewModel>();
            foreach (var parking in parkings)
            {
                parkingsVm.Add(CreateViewModelFromParking(parking));
            }

            return parkingsVm;
        }

        public async Task<ParkingViewModel> GetParkingAsync(int parkingId)
        {
            var parking = await _parkingRepository.GetByIdAsync(parkingId);
            return CreateViewModelFromParking(parking);
        }

        private ParkingViewModel CreateViewModelFromParking(Parking parking)
        {
            var viewModel =  new ParkingViewModel
            {
                Id = parking.Id, 
                Name = parking.Name, 
                Position = new GeoCoordinate(parking.CoordX, parking.CoordY)
            };
           
            return viewModel;
        }
    }
}