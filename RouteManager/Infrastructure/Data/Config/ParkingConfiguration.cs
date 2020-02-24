using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ParkingConfiguration : IEntityTypeConfiguration<Parking>
    {
        public void Configure(EntityTypeBuilder<Parking> builder)
        {
            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
                .UseHiLo("parking_hilo")
                .IsRequired();

            builder.Property(bi => bi.CoordX)
                .IsRequired(true);

            builder.Property(bi => bi.CoordX)
                .IsRequired(true);

            builder.Ignore(c => c.Position);
        }
    }
}
