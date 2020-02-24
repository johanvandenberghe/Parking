using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class ParkingDbContextSeed
    {
        public static async Task SeedAsync(ParkingDbContext parkingDbContext, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                // TODO: Only run this if using a real database
                // context.Database.Migrate();

                if (!parkingDbContext.Parkings.Any())
                {
                    parkingDbContext.Parkings.AddRange(GetDefaultParkings());

                    await parkingDbContext.SaveChangesAsync();
                }

                if (!parkingDbContext.Cars.Any())
                {
                    parkingDbContext.Cars.AddRange(
                        GetDefaultCars());

                    await parkingDbContext.SaveChangesAsync();
                }

                if (!parkingDbContext.Routes.Any())
                {
                    parkingDbContext.Routes.AddRange(
                        GetDefaultRoute());

                    await parkingDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    
                    await SeedAsync(parkingDbContext,retryForAvailability);
                }
                throw;
            }
        }

        static IEnumerable<Parking> GetDefaultParkings()
        {
            return new List<Parking>()
            {
                new Parking("Grand place", 4.354455, 50.848489),
                new Parking("La bas", 4.354455, 50.748489),
                new Parking("Ici", 4.354455, 50.748989f)
            };
        }

        static IEnumerable<Car> GetDefaultCars()
        {
            return new List<Car>()
            {
                new Car("BMW",8.00m,0.10m),
                new Car("VW", 5.50m, 0.30m),
                new Car("Fiat",6.40m, 0.60m)
            };
        }

        static IEnumerable<Route> GetDefaultRoute()
        {
            return new List<Route>()
            {
                new Route("work route", GetDefaultCars().First(), GetDefaultParkings().ElementAt(0), GetDefaultParkings().ElementAt(1)),
            };
        }
    }
}
