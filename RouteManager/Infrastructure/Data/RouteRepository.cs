using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class RouteRepository : EfRepository<Route>, IRouteRepository
    {
        public RouteRepository(ParkingDbContext dbContext) : base(dbContext)
        {
        }

        public Task<Route> GetByIdWithParkingsAndCarAsync(int id)
        {
            return _dbContext.Routes
                    .Include(r => r.DepartureParking)
                    .Include(r=> r.ArrivalParking)
                    .Include(r=> r.Car)
                    .FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Route>> GetAllWithParkingsAndCarAsync()
        {
            return _dbContext.Routes
                    .Include(r => r.DepartureParking)
                    .Include(r => r.ArrivalParking)
                    .Include(r => r.Car)
                    .ToListAsync(); ;
        }
    }
}
