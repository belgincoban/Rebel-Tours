using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RebelTours.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebelTours.Persistence.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(city => city.Id);

            builder.Property(city => city.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");
            builder.HasMany(city => city.Stations).
                WithOne(sta => sta.City).HasForeignKey(sta => sta.CityId);

            builder.HasData
                (
                    new City { Id=1, Name="İstanbul"},
                    new City { Id=2, Name="Ankara"},
                    new City { Id=3, Name="Bursa"},
                    new City { Id=4, Name="Muş"},
                    new City { Id=5, Name="Mersin"}
                );
        }
    }
}
