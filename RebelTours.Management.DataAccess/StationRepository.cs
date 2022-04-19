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
    public class StationRepository : IStationRepository
    {
        private readonly RebelToursDbContext _context;

        public StationRepository(RebelToursDbContext rebelToursDbContext)
        {
            _context = rebelToursDbContext;
        }

        public void Add(Station station)
        {
            _context.Stations.Add(station);
            _context.SaveChanges();
        }

        public Station Find(int id, params string[] includings)
        {
            var dbQuery = _context.Stations.AsQueryable();
            dbQuery = dbQuery.IncludeMultiple(includings);
            
            return dbQuery.SingleOrDefault(entity=>entity.Id==id);
        }

        public IEnumerable<Station> GetAll(params string[] includings)
        {
            var dbQuery = _context.Stations.AsQueryable();
            dbQuery = dbQuery.IncludeMultiple(includings);
            //if (includings !=null)
            //{
            //    foreach (var navProperty in includings)
            //    {
            //        dbQuery = dbQuery.Include(navProperty);
            //    }
            //}
            //if (includeCity)
            //{
            //    dbQuery = dbQuery.Include(s => s.City);
            //}

            return dbQuery.ToList();
        }

        public void Remove(Station station)
        {
            _context.Stations.Remove(station);
            _context.SaveChanges();
        }

        public void Update(Station station)
        {
            _context.Stations.Update(station);
            _context.SaveChanges();
        }
    }
}
