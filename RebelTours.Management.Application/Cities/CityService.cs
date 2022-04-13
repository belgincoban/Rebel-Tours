using RebelTours.Domain;
using RebelTours.Management.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RebelTours.Management.Application.Cities
{
    public class CityService : ICityService
    {
        //esas işi yapıcak sınıf

        private readonly ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        // Application katmanındaki CUD (Create, Update, Delete) metodları void olmayacak
        // 1. Validation yapmam gerekir
        // 2. DB'de bir hata meydana geldiyse bunu try-catch ile kontrol altına almam gerekir
        public void Create(CityDTO city)
        {
            var cityEntity = new City()
            {
                Name = city.Name
            };
            _cityRepository.Add(cityEntity);
        }


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

        public void Update(CityDTO cityDTO)
        {
            var city = _cityRepository.Find(cityDTO.Id);
            city.Name = cityDTO.Name;
            _cityRepository.Update(city);
        }

        public void Delete(CityDTO cityDTO)
        {

            if (cityDTO != null)
            {
                var city = new City()
                {
                    Id = cityDTO.Id,
                    Name = cityDTO.Name
                };
                _cityRepository.Remove(city);
            }
        }
    }
}
