using RebelTours.Domain;
using RebelTours.Management.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RebelTours.Management.Application.Stations
{
    public class StationService : IStationService
    {
        private readonly IStationRepository _stationRepository;

        public StationService(IStationRepository stationRepository)
        {
           _stationRepository = stationRepository;
        }
        public IEnumerable<StationDTO> GetAll()
        {
            var stationEntities = _stationRepository.GetAll();
            var stations = stationEntities.Select(s => new StationDTO()
            {
                Id = s.Id,
                Name = s.Name,
                CityId = s.CityId
            }).ToList();

            return stations;
        }

        public IEnumerable<StationSummary> GetSummaries()
        {
            var stationEntities = _stationRepository.GetAll("City");
            var stationsSummaries = new List<StationSummary>();
            foreach (var entity in stationEntities)
            {
                stationsSummaries.Add(new StationSummary()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    CityName = entity.City.Name
                });
            }
            return stationsSummaries;
        }

        public StationDTO GetById(int id)
        {
            var stationEntity = _stationRepository.Find(id);
            if (stationEntity != null)
            {
                var station = new StationDTO()
                {
                    Id = stationEntity.Id,
                    Name = stationEntity.Name,
                    CityId = stationEntity.CityId
                };

                return station;
            }
            else
            {
                return null;
            }
        }

        public CommandResult Create(StationDTO stationDTO)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(stationDTO.Name))
                {
                    return CommandResult.Error("İsim boş geçilemez");
                }

                var stationEntity = new Station()
                {
                    Id = stationDTO.Id,
                    Name = stationDTO.Name,
                    CityId = stationDTO.CityId
                };
                _stationRepository.Add(stationEntity);

                return CommandResult.Success(MessageProvider.CreateSuccessMessage);

            }
            catch (Exception ex)
            {
                return CommandResult.Error(
                   MessageProvider.CreateErrorMessage,
                   ex.Message);
            }

        }

        public CommandResult Update(StationDTO stationDTO)
        {
            try
            {
                var station = _stationRepository.Find(stationDTO.Id);
                station.Name = stationDTO.Name;
                station.CityId = stationDTO.CityId;

                _stationRepository.Update(station);

                return CommandResult.Success(MessageProvider.UpdateSuccessMessage);
            }
            catch (Exception ex)
            {
                return CommandResult.Error(
                    MessageProvider.UpdateErrorMessage,
                    ex.Message);
            }

        }

        public CommandResult Delete(StationDTO stationDTO)
        {
            try
            {
                if (stationDTO != null)
                {
                    var station = new Station()
                    {
                        Id = stationDTO.Id,
                        Name = stationDTO.Name,
                        CityId = stationDTO.CityId
                    };

                    _stationRepository.Remove(station);

                    return CommandResult.Success(MessageProvider.DeleteSuccessMessage);
                }
                else
                {
                    return CommandResult.Error("Silinecek istasyon bulunamadı");
                }

            }
            catch (Exception ex)
            {
                return CommandResult.Error(
                   MessageProvider.DeleteErrorMessage,
                   ex.Message);
            }
           
        }
    }
}
