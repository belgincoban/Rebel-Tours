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
        public void Create(BusModelDTO modelDTO)
        {
            var busModel = new BusModel(modelDTO.Id, modelDTO.Name, modelDTO.BusManufacturerId, modelDTO.Type, modelDTO.SeatCapacity, modelDTO.HasToilet);
            _busModel.Add(busModel);
        }

        public void Delete(BusModelDTO modelDTO)
        {
            if (modelDTO != null)
            {
                var busModel = new BusModel(modelDTO.Id, modelDTO.Name, modelDTO.BusManufacturerId, modelDTO.Type, modelDTO.SeatCapacity, modelDTO.HasToilet);
                _busModel.Remove(busModel);
            }
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
            var busModel = _busModel.GetAll(true);
            var modelSummaries = new List<BusModelSummaryDTO>();
            foreach (var entity in busModel)
            {
                modelSummaries.Add(new BusModelSummaryDTO()
                {
                    Id=entity.Id,
                    Name=entity.Name,
                    ManufacturerName = entity.BusManufacturer.Name,
                    Type=entity.Type,
                    SeatCapacity=entity.SeatCapacity,
                    HasToilet=entity.HasToilet
                });
            }
            return modelSummaries;
        }

        public void Update(BusModelDTO modelDTO)
        {
            var busModels = _busModel.Find(modelDTO.Id);
            busModels.Name = modelDTO.Name;
            _busModel.Update(busModels);
            
        }
    }
}
