using RebelTours.Domain;
using RebelTours.Management.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RebelTours.Management.Application.Buses
{
    public class BusService:IBusService
    {
        private readonly IBusRepository _busRepository;

        public BusService(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }

        public IEnumerable<BusDTO> GetAll()
        {
            var busEntities = _busRepository.GetAll();
            var buses = busEntities.Select(b=> new BusDTO()
            {
                BusId = b.BusId,
                BusModelId = b.BusModelId,
                RegistrationPlate = b.RegistrationPlate,
                Year = b.Year,
                SeatMapping = b.SeatMapping,
                DistanceTraveled = b.DistanceTraveled
            });

            return buses;
        }

        public BusDTO GetById(int id)
        {
            var busEntities = _busRepository.Find(id);
            if (busEntities != null)
            {
                var buses = new BusDTO()
                {
                    BusId = busEntities.BusId,
                    BusModelId = busEntities.BusModelId,
                    RegistrationPlate = busEntities.RegistrationPlate,
                    Year = busEntities.Year,
                    SeatMapping = busEntities.SeatMapping,
                    DistanceTraveled = busEntities.DistanceTraveled
                };
                return buses;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<BusSummaryDTO> GetSummaries()
        {
            var busEntities = _busRepository.GetAll("BusModel");
            var buses = busEntities.Select(entity => new BusSummaryDTO
            {
                BusId = entity.BusId,
                BusModelName = entity.BusModel.Name,
                RegistrationPlate = entity.RegistrationPlate,
                Year = entity.Year,
                SeatMapping = entity.SeatMapping,
                SeatCount=entity.SeatCount,
                DistanceTraveled = entity.DistanceTraveled
            });

            return buses;
        }

        public CommandResult Create(BusDTO busDTO)
        {
            try
            {
                var busEntities = new Bus(
                    busDTO.BusId,
                    busDTO.BusModelId,
                    busDTO.RegistrationPlate,
                    busDTO.Year,
                    busDTO.SeatMapping, 
                    busDTO.DistanceTraveled);
                _busRepository.Add(busEntities);

                return CommandResult.Success(MessageProvider.CreateSuccessMessage);
            }
            catch (Exception ex)
            {
                return CommandResult.Error(
                  MessageProvider.CreateErrorMessage,
                  ex.Message);
            }         
        }

        public CommandResult Delete(BusDTO busDTO)
        {
            try
            {
                if (busDTO != null)
                {
                    var busEntity = _busRepository.Find(busDTO.BusId);
                    _busRepository.Remove(busEntity);

                    return CommandResult.Success(MessageProvider.DeleteSuccessMessage);
                }
                else
                {
                    return CommandResult.Error("Silinecek Otobüs bulunamadı");
                }
            }
            catch (Exception ex)
            {
                return CommandResult.Error(
                 MessageProvider.DeleteErrorMessage,
                 ex.Message);
            }

        }

        public CommandResult Update(BusDTO busDTO)
        {
            try
            {
                var busEntity = _busRepository.Find(busDTO.BusId);
                busEntity.SeatMapping = busDTO.SeatMapping;
                busEntity.DistanceTraveled = busDTO.DistanceTraveled;

                _busRepository.Update(busEntity);

                return CommandResult.Success(MessageProvider.UpdateSuccessMessage);
            }
            catch (Exception ex)
            {
                return CommandResult.Error(
                   MessageProvider.UpdateErrorMessage,
                   ex.Message);
            }
         
        }
    }
}
