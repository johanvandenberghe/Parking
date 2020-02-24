using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Ardalis.GuardClauses;

namespace ApplicationCore.Services
{
    public class ParkingService : IParkingService
    {
        private readonly IAsyncRepository<Parking> _parkingRepository;

        public ParkingService(IAsyncRepository<Parking> parkingRepository)
        {
            _parkingRepository = parkingRepository;
        }

        public async Task CreateParkingAsync(string name, double coordX, double coordY)
        {
            var parking = new Parking(name, coordX, coordY);
            Guard.Against.NullOrWhiteSpace(name, nameof(name));

            await _parkingRepository.AddAsync(parking);
        }
    }
}
