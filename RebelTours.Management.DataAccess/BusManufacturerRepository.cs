using RebelTours.Domain;
using RebelTours.Management.Application.Repositories;
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

        public BusManufacturer Find(int id)
        {
            var busManufacturer= _context.BusManufacturers.Find(id);
            return busManufacturer;
        }

        public IEnumerable<BusManufacturer> GetAll()
        {
            
            return _context.BusManufacturers.ToList();
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
