using System.Collections.Generic;
using System.Threading.Tasks;
using RouteManager.ViewModels;

namespace RouteManager.Interfaces
{
    public interface ICarViewModelService
    {
        Task<IEnumerable<CarViewModel>> GetAllcarAsync();
        Task<CarViewModel> GetCarAsync(int carId);
    }
}