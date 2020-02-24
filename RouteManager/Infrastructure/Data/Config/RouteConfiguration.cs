using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            //var navigationDepartureParking = builder.Metadata.FindNavigation(nameof(Route.DepartureParking));
            //navigationDepartureParking.SetPropertyAccessMode(PropertyAccessMode.Field);

            //var navigationArrivalParking = builder.Metadata.FindNavigation(nameof(Route.ArrivalParking));
            //navigationArrivalParking.SetPropertyAccessMode(PropertyAccessMode.Field);

            //var navigationCar = builder.Metadata.FindNavigation(nameof(Route.Car));
            //navigationArrivalParking.SetPropertyAccessMode(PropertyAccessMode.Field);



            builder.HasOne(p => p.DepartureParking)
                   .WithMany(p=> p.RoutesDeparture).HasForeignKey(x => x.DepartureParkingId)
                   .OnDelete(DeleteBehavior.NoAction); ;

            builder.HasOne(p => p.ArrivalParking)
                .WithMany(p => p.RoutesDestination).HasForeignKey(x => x.ArrivalParkingId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Car)
                .WithMany(p => p.Routes).HasForeignKey(x => x.CarId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .UseHiLo("route_hilo")
               .IsRequired();

            builder.Property(cb => cb.CarId).IsRequired();

            builder.Property(cb => cb.DepartureParkingId).IsRequired();

            builder.Property(cb => cb.ArrivalParkingId).IsRequired();
        }
    }
}
