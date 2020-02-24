using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IRouteService
    {
        Task CreateRouteAsync(string name, int carId, int departureParkingId, int arrivalParkingId);
        Task UpadeRouteAsync(int routeId, string name, int carId, int departureParkingId, int arrivalParkingId);
        Task DeleteRouteAsync(int routeId);
        Task SetDestination(int routeId, int parkingId);
        Task SetDeparture(int routeId, int parkingId);
    }
}
