using Microsoft.EntityFrameworkCore;
using RebelTours.Domain;
using RebelTours.Management.Application.Repositories;
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

        public Station Find(int id)
        {
            return _context.Stations.Find(id);
        }

        public IEnumerable<Station> GetAll()
        {
            return GetAll(false);
        }
        public IEnumerable<Station> GetAll(bool includeCity)
        {
            var dbQuery = _context.Stations.AsQueryable();
            if (includeCity)
            {
                dbQuery = dbQuery.Include(s => s.City);
            }
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
