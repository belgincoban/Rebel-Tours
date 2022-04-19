using RebelTours.Domain;
using RebelTours.Management.Application.Repositories;
using RebelTours.Management.DataAccess.Extensions;
using RebelTours.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RebelTours.Management.DataAccess
{
    public class BusManufacturerRepository : IBusManufacturerRepository
    {
        private readonly RebelToursDbContext _context;

        public BusManufacturerRepository(RebelToursDbContext rebelToursDbContext)
        {
            _context = rebelToursDbContext;
        }
        public void Add(BusManufacturer busManufacturer)
        {
            _context.BusManufacturers.Add(busManufacturer);
            _context.SaveChanges();
        }

        public BusManufacturer Find(int id, params string[] includings)
        {
            var dbQuery = _context.BusManufacturers.AsQueryable();
            dbQuery = dbQuery.IncludeMultiple(includings);

            return dbQuery.SingleOrDefault(entity => entity.Id == id);
        }

        public IEnumerable<BusManufacturer> GetAll(params string[] includings)
        {

            var dbQuery = _context.BusManufacturers.AsQueryable();
            dbQuery = dbQuery.IncludeMultiple(includings);
            return dbQuery.ToList();
        }

        public void Remove(BusManufacturer busManufacturer)
        {
             _context.BusManufacturers.Remove(busManufacturer);
            _context.SaveChanges();
        }

        public void Update(BusManufacturer busManufacturer)
        {
            _context.BusManufacturers.Update(busManufacturer);
            _context.SaveChanges();
        }
    }
}
