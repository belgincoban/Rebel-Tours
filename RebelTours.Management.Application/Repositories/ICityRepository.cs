using RebelTours.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RebelTours.Management.Application.Repositories
{
    public interface ICityRepository
    {
        //City çünkü bana veritabanından o domain nesnesinin gelmesi gerekecek, application'ım şuan
        //Repository'i application kullanacak 
        IEnumerable<City> GetAll();
        void Add(City city);
        City Find(int id);
        void Update(City city);
        void Remove(City city);


    }
}
