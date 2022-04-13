using System;
using System.Collections.Generic;
using System.Text;

namespace RebelTours.Management.Application.BusManufacturers
{
    public interface IBusManufacturerService
    {
        IEnumerable<BusManufacturerDTO> GetAll();
        BusManufacturerDTO GetById(int id);
        void Create(BusManufacturerDTO  busManufacturer);
        void Update(BusManufacturerDTO busManufacturer);
        void Delete(BusManufacturerDTO busManufacturer);
    }
}
