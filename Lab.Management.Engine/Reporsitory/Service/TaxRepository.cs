using Lab.Management.Engine.Reporsitory.Generic;
using Lab.Management.Engine.Reporsitory.Interface;
using Lab.Management.Entities;
using System.Linq;

namespace Lab.Management.Engine.Reporsitory.Service
{
    public class TaxRepository : GenericRepository<LabManagementEntities, lmsTaxMaster>, ITaxRepository
    {
        public lmsTaxMaster GetSingle(int id)
        {
            var query = GetAll().FirstOrDefault(x => x.TAXID == id);
            return query; ;
        }
    }
}
