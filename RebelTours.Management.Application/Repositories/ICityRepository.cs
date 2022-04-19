using RebelTours.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RebelTours.Management.Application.Repositories
{
    public interface ICityRepository:IRepository<City>
    {
        //City çünkü bana veritabanından o domain nesnesinin gelmesi gerekecek, application'ım şuan
        //Repository'i application kullanacak 

    }
}
