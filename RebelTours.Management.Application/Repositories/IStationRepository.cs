using RebelTours.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RebelTours.Management.Application.Repositories
{
   public interface IStationRepository
    {
        IEnumerable<Station> GetAll(bool includeCity=false);
        Station Find(int id);
        void Update(Station station);
        void Add(Station station);
        void Remove(Station station);
    }
}
