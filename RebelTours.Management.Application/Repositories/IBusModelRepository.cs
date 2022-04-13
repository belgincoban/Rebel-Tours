using RebelTours.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RebelTours.Management.Application.Repositories
{
    public interface IBusModelRepository
    {
        IEnumerable<BusModel> GetAll(bool includeManufacturer = false);
        BusModel Find(int id);
        void Update(BusModel busModel);
        void Add(BusModel busModel);
        void Remove(BusModel busModel);
    }
}
