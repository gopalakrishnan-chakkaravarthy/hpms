using Lab.Management.Engine.Reporsitory.Generic;
using Lab.Management.Engine.Reporsitory.Interface;
using Lab.Management.Entities;
using System.Linq;


namespace Lab.Management.Engine.Reporsitory.Service
{
    public class LabTaxRepository : GenericRepository<LabManagementEntities, lmsLabTax>, ILabTaxRepository
    {
        public lmsLabTax GetSingle(int id)
        {
            var query = GetAll().FirstOrDefault(x => x.LTAXID == id);
            return query; ;
        }
    }
}
