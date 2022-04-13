using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RebelTours.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RebelTours.Persistence.Configurations
{
    public class BusModelConfiguration : IEntityTypeConfiguration<BusModel>
    {
        public void Configure(EntityTypeBuilder<BusModel> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).IsRequired().HasColumnType("varchar(100)");
            builder.HasOne(b => b.BusManufacturer)
               .WithMany()
               .HasForeignKey(b => b.BusManufacturerId);
            builder.Property(b => b.Type).HasConversion(
                busType => (int)busType,
                intValue => (BusType)intValue);
            builder.Property(b => b.SeatCapacity).HasColumnType("int");
            builder.Property(b => b.HasToilet).HasColumnType("bit");

            builder.HasData(
                 new BusModel(1, "CityLiner", 1, BusType.Coach, 52, false) { },
                 new BusModel(2, "Travego", 2, BusType.Coach, 44, false) { },
                 new BusModel(3, "S 415", 3, BusType.Coach, 48, false) { }
                 );

        }
    }
}
