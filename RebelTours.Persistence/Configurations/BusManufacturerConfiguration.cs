using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RebelTours.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RebelTours.Persistence.Configurations
{
    public class BusManufacturerConfiguration : IEntityTypeConfiguration<BusManufacturer>
    {
        public void Configure(EntityTypeBuilder<BusManufacturer> builder)
        {
            builder.HasKey(bm => bm.Id);
            builder.Property(bm => bm.Name).IsRequired().HasColumnType("varchar(100)");

            builder.HasData
               (
                   new BusManufacturer (1,"Mercedes"),
                   new BusManufacturer (2,"Travego"),                
                   new BusManufacturer (3,"Svf")                
               );
        }
    }
}
