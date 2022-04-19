using RebelTours.Domain;
using RebelTours.Management.Application.Repositories;
using RebelTours.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RebelTours.Management.DataAccess
{
    public class CityRepository : ICityRepository
    {
        public void Add(City city)
        {
            var dbContext = new RebelToursDbContext();
            dbContext.Cities.Add(city);
            dbContext.SaveChanges();
        }

        public IEnumerable<City> GetAll(params string[] includings)
        {
            //veritabanına erişim sağlıyorum bu sınıfla.
           
            var dbContext = new RebelToursDbContext();
            return dbContext.Cities.ToList();
        }

        public City Find(int id, params string[] includings)
        {
            var dbContext = new RebelToursDbContext();
            var city=dbContext.Cities.Find(id);
            return city;

        }

        public void Update(City city)
        {
            var dbContext = new RebelToursDbContext();
            dbContext.Cities.Update(city);
            dbContext.SaveChanges();
        }
        public void Remove(City city)
        {
            var dbContext = new RebelToursDbContext();
            dbContext.Cities.Remove(city);
            dbContext.SaveChanges();
        }
    }
}
