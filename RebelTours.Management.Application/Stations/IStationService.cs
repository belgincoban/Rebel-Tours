using System;
using System.Collections.Generic;
using System.Text;

namespace RebelTours.Management.Application.Stations
{
    public interface IStationService
    {
        StationDTO GetById(int id);
        IEnumerable<StationDTO> GetAll();
        IEnumerable<StationSummary> GetSummaries();
        void Create(StationDTO stationDTO);
        void Update(StationDTO stationDTO);
        void Delete(StationDTO stationDTO);

    }
}
