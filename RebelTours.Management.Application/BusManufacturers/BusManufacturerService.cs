using RebelTours.Domain;
using RebelTours.Management.Application.Cities;
using RebelTours.Management.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RebelTours.Management.Application.BusManufacturers
{
    public class BusManufacturerService : IBusManufacturerService
    {
        private readonly IBusManufacturerRepository _manufacturerRepository;

        public BusManufacturerService(IBusManufacturerRepository manufacturerRepository)
        {
            _manufacturerRepository = manufacturerRepository;
        }

        public IEnumerable<BusManufacturerDTO> GetAll()
        {
            var manufacturerEntities = _manufacturerRepository.GetAll();
            var busManufacturers = manufacturerEntities.Select(entity => new BusManufacturerDTO
            {
                Id = entity.Id,
                Name = entity.Name
            });
            return busManufacturers;
        }

        public BusManufacturerDTO GetById(int id)
        {
            var busManufacturer = _manufacturerRepository.Find(id);

            if (busManufacturer != null)
            {
                var manuFacturer = new BusManufacturerDTO()
                {
                    Id = busManufacturer.Id,
                    Name = busManufacturer.Name
                };

                return manuFacturer;
            }
            else
            {
                return null;
            }
        }

        public CommandResult Create(BusManufacturerDTO busManufacturer)
        {
            try
            {
                var manuFacturer = new BusManufacturer(
                    busManufacturer.Id,
                    busManufacturer.Name);
                _manufacturerRepository.Add(manuFacturer);

                return CommandResult.Success(MessageProvider.CreateSuccessMessage);
            }
            catch (Exception ex)
            {
                return CommandResult.Error(
                 MessageProvider.CreateErrorMessage,
                 ex.Message);
            }
        }

        public CommandResult Delete(BusManufacturerDTO busManufacturerDTO)
        {
            try
            {
                if (busManufacturerDTO != null)
                {
                    var busManufacturer = new BusManufacturer(busManufacturerDTO.Id, busManufacturerDTO.Name);
                    _manufacturerRepository.Remove(busManufacturer);

                    return CommandResult.Success(MessageProvider.DeleteSuccessMessage);
                }
                else
                {
                    return CommandResult.Error("Silinecek marka bulunamadı");
                }
            }
            catch (Exception ex)
            {
                return CommandResult.Error(
                 MessageProvider.DeleteErrorMessage,
                 ex.Message);
            }
         
        }

        public CommandResult Update(BusManufacturerDTO busManufacturer)
        {
            try
            {
                var manufacturer = _manufacturerRepository.Find(busManufacturer.Id);
                manufacturer.Name = busManufacturer.Name;
                _manufacturerRepository.Update(manufacturer);

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
