using Microsoft.EntityFrameworkCore;
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
    public class BusModelRepository : IBusModelRepository
    {
        private readonly RebelToursDbContext _context;

        public BusModelRepository(RebelToursDbContext rebelToursDbContext)
        {
           _context = rebelToursDbContext;
        }

        public void Add(BusModel busModel)
        {
            _context.BusModels.Add(busModel);
            _context.SaveChanges();
        }

        public BusModel Find(int id, params string[] includings)
        {
            return _context.BusModels
                  .IncludeMultiple(includings)
                  .SingleOrDefault(entity => entity.Id == id);

        }

        public IEnumerable<BusModel> GetAll(params string[] includings)
        {
            var dbQuery = _context.BusModels.AsQueryable();
            dbQuery = dbQuery.IncludeMultiple(includings);
            return dbQuery.ToList();
        }

        public void Remove(BusModel busModel)
        {
            _context.BusModels.Remove(busModel);
            _context.SaveChanges();
        }

        public void Update(BusModel busModel)
        {
            _context.BusModels.Update(busModel);
            _context.SaveChanges();
        }
    }
}
