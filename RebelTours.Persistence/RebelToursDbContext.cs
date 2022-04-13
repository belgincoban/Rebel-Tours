using Microsoft.EntityFrameworkCore;
using RebelTours.Domain;
using RebelTours.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebelTours.Persistence
{
    public class RebelToursDbContext:DbContext
    {
        private const string ConnectionString = "Server=.; Database=RebelToursDb; Integrated Security=true;";
        public DbSet<City> Cities { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<BusModel> BusModels { get; set; }
        public DbSet<BusManufacturer> BusManufacturers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CityConfiguration());

            modelBuilder.ApplyConfiguration(new StationConfiguration());
            modelBuilder.ApplyConfiguration(new BusModelConfiguration());
            modelBuilder.ApplyConfiguration(new BusManufacturerConfiguration());

        }
   

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectionString);
            
        }
    }
}
