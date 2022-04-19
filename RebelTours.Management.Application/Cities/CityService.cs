using RebelTours.Domain;
using RebelTours.Management.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RebelTours.Management.Application.Cities
{
    public class CityService : ICityService
    {
        //esas işi yapıcak sınıf
        private const string CreateErrorMessage = "Kaydetme aşamasında bir hata meydana geldi";

        private readonly ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        // Application katmanındaki CUD (Create, Update, Delete) metodları void olmayacak
        // 1. Validation yapmam gerekir
        // 2. DB'de bir hata meydana geldiyse bunu try-catch ile kontrol altına almam gerekir
  

        public IEnumerable<CityDTO> GetAll()
        {
            var cityEntities = _cityRepository.GetAll();

            var cityDTOs = new List<CityDTO>();
 
            foreach (var entity in cityEntities)
            {
                //city nesnesini cityDTOs nesnesine mapping yapıyorum.
                cityDTOs.Add(new CityDTO()
                {
                    Id = entity.Id,
                    Name = entity.Name
                });
            }
            return cityDTOs;
        }

        public CityDTO GetById(int id)
        {
            var cityEntity = _cityRepository.Find(id);

            if (cityEntity != null)
            {
                var city = new CityDTO()
                {
                    Id = cityEntity.Id,
                    Name = cityEntity.Name
                };

                return city;
            }
            else
            {
                return null;
            }
        }

 
        public CommandResult Create(CityDTO city)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(city.Name))
                {
                    return CommandResult.Error("İsim boş geçilemez");
                }

                var cityRep = new City()
                {
                    Name = city.Name
                };

                _cityRepository.Add(cityRep);

                return CommandResult.Success(MessageProvider.CityCreateSuccessMessage);
            }
            catch (Exception)
            {
                return CommandResult.Error(CreateErrorMessage);
            }
        }

        public CommandResult Update(CityDTO cityDTO)
        {
            try
            {
                var cityEntities = _cityRepository.Find(cityDTO.Id);

                cityEntities.Name = cityDTO.Name;

                _cityRepository.Update(cityEntities);

                return CommandResult.Success(MessageProvider.UpdateSuccessMessage);
            }
            catch (Exception ex)
            {
                return CommandResult.Error(MessageProvider.UpdateErrorMessage,ex.Message);
            }
        }

        public CommandResult Delete(CityDTO cityDTO)
        {

            try
            {
                var entityCity = _cityRepository.Find(cityDTO.Id);
                _cityRepository.Remove(entityCity);

                return CommandResult.Success(MessageProvider.DeleteSuccessMessage);
            }
            catch (Exception ex)
            {
                return CommandResult.Error(
                   MessageProvider.DeleteErrorMessage,ex.Message);
            }
        }

    }
}
