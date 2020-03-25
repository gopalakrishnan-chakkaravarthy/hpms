using Lab.Management.Entities;
using System.Collections.Generic;
namespace Lab.Management.Engine.Service.Drugs
{
    public interface IDrugDetailService
    {
        bool Save(lmsDrugDetail entity);

        IEnumerable<lmsDrugDetail> GetAll();

        lmsDrugDetail Get(int id);

        bool Remove(int id);
    }
}
