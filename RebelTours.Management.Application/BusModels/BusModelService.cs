using RebelTours.Domain;
using RebelTours.Management.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RebelTours.Management.Application.BusModels
{
    public class BusModelService : IBusModelService
    {
        private readonly IBusModelRepository _busModel;

        public BusModelService(IBusModelRepository busModel)
        {
            _busModel = busModel;
        }

        public IEnumerable<BusModelDTO> GetAll()
        {
            
            var busModel = _busModel.GetAll();
            var models = busModel.Select(m=> new BusModelDTO() 
            {
               Id= m.Id,
                Name=m.Name,
                BusManufacturerId= m.BusManufacturerId,
                Type=m.Type,
                SeatCapacity=m.SeatCapacity,
                HasToilet=m.HasToilet
            });

            return models;
        }

        public BusModelDTO GetById(int id)
        {
            var busModel = _busModel.Find(id);
            if (busModel != null)
            {
                var models = new BusModelDTO()
                {
                    Id = busModel.Id,
                    Name = busModel.Name,
                    BusManufacturerId = busModel.BusManufacturerId,
                    Type = busModel.Type,
                    SeatCapacity = busModel.SeatCapacity,
                    HasToilet = busModel.HasToilet
                };
                return models;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<BusModelSummaryDTO> GetSummaries()
        {
            var busModel = _busModel.GetAll("BusManufacturer");
            var busModels = busModel.Select(entity => new BusModelSummaryDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                BusManufacturerName = entity.BusManufacturer.Name,
                Type = entity.Type,
                SeatCapacity = entity.SeatCapacity,
                HasToilet = entity.HasToilet
            });
            return busModels;
        }

        public CommandResult Create(BusModelDTO modelDTO)
        {
            try
            {
                var busModel = new BusModel(
                    modelDTO.Id,
                    modelDTO.Name,
                    modelDTO.BusManufacturerId,
                    modelDTO.Type,
                    modelDTO.SeatCapacity,
                    modelDTO.HasToilet
                    );

                _busModel.Add(busModel);
                return CommandResult.Success(MessageProvider.CreateSuccessMessage);
            }
            catch (Exception ex)
            {
                return CommandResult.Error(
                  MessageProvider.CreateErrorMessage,
                  ex.Message);
            }
          
        }

        public CommandResult Delete(BusModelDTO modelDTO)
        {
            try
            {
                if (modelDTO != null)
                {
                    var busModel = _busModel.Find(modelDTO.Id);
                    _busModel.Remove(busModel);

                    return CommandResult.Success(MessageProvider.DeleteSuccessMessage);
                }
                else
                {
                    return CommandResult.Error("Silinecek model bulunamadı");
                }
            }
            catch (Exception ex)
            {
                return CommandResult.Error(
                  MessageProvider.DeleteErrorMessage,
                  ex.Message);
            }
           
        }

        public CommandResult Update(BusModelDTO modelDTO)
        {
            try
            {
                var busModels = _busModel.Find(modelDTO.Id);
                busModels.Name = modelDTO.Name;
                _busModel.Update(busModels);

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
