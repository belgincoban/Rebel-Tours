using System;
using System.Collections.Generic;
using System.Text;

namespace RebelTours.Management.Application.Repositories
{

    //generic
    //Hangi başka tip için bu interface oluşturulacaksa, o bahsettiğimiz "başka tip"'i generic tip olarak
    //(tip parametresi olarak oluşturunuz.)
    public interface IRepository<TEntity>
    {
        TEntity Find(int id, params string[] includings);
        IEnumerable<TEntity> GetAll( params string[] includings );
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);

    }
}
