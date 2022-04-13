using System;
using System.Collections.Generic;
using System.Text;

namespace RebelTours.Management.Application.BusModels
{
    public interface IBusModelService
    {
        BusModelDTO GetById(int id);
        IEnumerable<BusModelDTO> GetAll();
        IEnumerable<BusModelSummaryDTO> GetSummaries();
        void Create(BusModelDTO modelDTO);
        void Update(BusModelDTO modelDTO);
        void Delete(BusModelDTO modelDTO);
    }
}
