using Lab.Management.Engine.Models;
using Lab.Management.Entities;
using System.Collections.Generic;

namespace Lab.Management.Engine.Service.Tax
{
    public interface ITaxService
    {
        bool Save(lmsTaxMaster entity);

        IEnumerable<lmsTaxMaster> GetAll();
        IList<DropDown> GetTaxList();
        lmsTaxMaster Get(int id);
        int GetIdByText(string taxName);

        bool Remove(int id);
    }
}
