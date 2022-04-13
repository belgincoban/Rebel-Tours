using RebelTours.Domain;
using RebelTours.Management.Application.Cities;
using RebelTours.Management.Application.Repositories;
using System;
using System.Collections.Generic;
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

        public void Create(BusManufacturerDTO busManufacturer)
        {
            var manuFacturer = new BusManufacturer(busManufacturer.Id,busManufacturer.Name);
            _manufacturerRepository.Add(manuFacturer);
        }

        public void Delete(BusManufacturerDTO busManufacturerDTO)
        {
            if (busManufacturerDTO != null)
            {
                var busManufacturer = new BusManufacturer(busManufacturerDTO.Id, busManufacturerDTO.Name);
                _manufacturerRepository.Remove(busManufacturer);
            }
        }

        public IEnumerable<BusManufacturerDTO> GetAll()
        {
            var manufacturer = _manufacturerRepository.GetAll();
            var manufacturerDTOs = new List<BusManufacturerDTO>();
            foreach (var entity in manufacturer)
            {
                manufacturerDTOs.Add(new BusManufacturerDTO
                {
                    Id = entity.Id,
                    Name = entity.Name
                });
            }
            return manufacturerDTOs;
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

        public void Update(BusManufacturerDTO busManufacturer)
        {
            var manuFacturer = _manufacturerRepository.Find(busManufacturer.Id);
            manuFacturer.Name = busManufacturer.Name;
            _manufacturerRepository.Update(manuFacturer);
        }
    }
}
