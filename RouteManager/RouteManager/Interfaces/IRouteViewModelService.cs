using System.Collections.Generic;
using System.Threading.Tasks;
using RouteManager.ViewModels;

namespace RouteManager.Interfaces
{
    public interface IRouteViewModelService
    {
        Task<IEnumerable<RouteViewModel>> GetAllRouteAsync();

        Task<EditRouteViewModel> GetRouteEditAsync(int? routeId);
    }
}