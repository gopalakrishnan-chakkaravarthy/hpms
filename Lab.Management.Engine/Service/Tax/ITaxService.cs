using Lab.Management.Engine.Enum;
using Lab.Management.Entities;
using System.Collections.Generic;

namespace Lab.Management.Engine.Service.Tax
{
    public interface ITaxService
    {
        bool Save(lmsTaxMaster entity);

        IEnumerable<lmsTaxMaster> GetAll();

        lmsTaxMaster Get(int id);
        int GetIdByText(string taxName);

        bool Remove(int id);
    }
}
