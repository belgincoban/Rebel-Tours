using RebelTours.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RebelTours.Management.Application.Repositories
{
    public interface IBusManufacturerRepository
    {
        IEnumerable<BusManufacturer> GetAll();
        void Add(BusManufacturer busManufacturer);
        BusManufacturer Find(int id);
        void Update(BusManufacturer busManufacturer);
        void Remove(BusManufacturer busManufacturer);
    }
}
