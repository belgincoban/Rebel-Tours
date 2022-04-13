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
    public class StationConfiguration : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            builder.HasKey(station => station.Id);

            builder.Property(station => station.Name).IsRequired().HasColumnType("varchar(100)");

            builder.HasOne(station => station.City)
                .WithMany(city=>city.Stations)
                .HasForeignKey(sta => sta.CityId);

            builder.HasData
                (
                    new Station { Id=1, Name="Esenler", CityId=1},
                    new Station { Id=2, Name="Alibeyköy", CityId=1},
                    new Station { Id=3, Name="Aşri", CityId=2},
                    new Station { Id=4, Name="Dudullu", CityId=3}
                );

        }
    }
}
