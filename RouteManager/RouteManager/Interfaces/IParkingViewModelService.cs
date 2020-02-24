using System.Collections.Generic;
using System.Threading.Tasks;
using RouteManager.ViewModels;

namespace RouteManager.Interfaces
{
    public interface IParkingViewModelService
    {
        Task<IEnumerable<ParkingViewModel>> GetAllParkingAsync();
        Task<ParkingViewModel> GetParkingAsync(int routeId);
    }
}