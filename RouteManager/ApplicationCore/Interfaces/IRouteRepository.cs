using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IRouteRepository : IAsyncRepository<Route>
    {
        Task<Route> GetByIdWithParkingsAndCarAsync(int id);
        Task<List<Route>> GetAllWithParkingsAndCarAsync();
    }
}
