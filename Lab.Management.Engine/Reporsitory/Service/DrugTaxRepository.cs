using Lab.Management.Engine.Reporsitory.Generic;
using Lab.Management.Engine.Reporsitory.Interface;
using Lab.Management.Entities;
using System.Linq;

namespace Lab.Management.Engine.Reporsitory.Service
{
    public class DrugTaxRepository : GenericRepository<LabManagementEntities, lmsDrugsTax>, IDrugTaxRepository
    {
        public lmsDrugsTax GetSingle(int id)
        {
            var query = GetAll().FirstOrDefault(x => x.DTAXID == id);
            return query; ;
        }
    }
}
