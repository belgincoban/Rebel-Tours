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
    public class BusRepository : IBusRepository
    {
        private readonly RebelToursDbContext _context;

        public BusRepository(RebelToursDbContext rebelToursDbContext)
        {
            _context = rebelToursDbContext;
        }
        public void Add(Bus bus)
        {
            _context.Buses.Add(bus);
            _context.SaveChanges();
        }

        public Bus Find(int id, params string[] includings)
        {
            return _context.Buses
                 .IncludeMultiple(includings)
                 .SingleOrDefault(entity => entity.BusId== id);
        }

        public IEnumerable<Bus> GetAll(params string[] includings)
        {
            var dbQuery = _context.Buses.AsQueryable();
            dbQuery = dbQuery.IncludeMultiple(includings);
            return dbQuery.ToList();
        }

        public void Remove(Bus bus)
        {
            _context.Buses.Remove(bus);
            _context.SaveChanges();
        }

        public void Update(Bus bus)
        {
            _context.Buses.Update(bus);
            _context.SaveChanges();
        }
    }
}
