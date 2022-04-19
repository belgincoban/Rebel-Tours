using System;
using System.Collections.Generic;
using System.Text;

namespace RebelTours.Management.Application
{
    public interface IService<TDTO>
    {
        TDTO GetById(int id);
        IEnumerable<TDTO> GetAll();
        CommandResult Create(TDTO entity);
        CommandResult Update(TDTO entity);
        CommandResult Delete(TDTO entity);
    }

    public interface IService<TDTO, TSummaryDTO> : IService<TDTO>
    {
        IEnumerable<TSummaryDTO> GetSummaries();
    }
}
