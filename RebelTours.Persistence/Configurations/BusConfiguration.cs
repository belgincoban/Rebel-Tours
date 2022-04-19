using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RebelTours.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RebelTours.Persistence.Configurations
{
    public class BusConfiguration : IEntityTypeConfiguration<Bus>
    {
        public void Configure(EntityTypeBuilder<Bus> builder)
        {
            builder.HasKey(b => b.BusId);

            builder.Property(b => b.RegistrationPlate).IsRequired().HasMaxLength(150);

            builder.HasOne(b => b.BusModel).WithMany().HasForeignKey(b => b.BusModelId);

            builder.Property(b => b.Year).HasColumnType("int");

            builder.Property(b => b.SeatMapping).IsRequired().HasColumnType("int");

            builder.Property(b => b.DistanceTraveled).IsRequired().HasColumnType("int");

            builder.HasData(
                new Bus(1, 2, "14-AA-14", 2012, SeatingType.Standard, 10000),
                new Bus(2, 3, "24-BB-24", 2013, SeatingType.Standard, 20000),
                new Bus(3, 3, "34-CC-34", 2014, SeatingType.Standard, 30000)
                );

        }
    }

}

