using Lab.Management.Engine.Reporsitory.Generic;
using Lab.Management.Engine.Reporsitory.Interface;
using Lab.Management.Entities;
using System.Linq;

namespace Lab.Management.Engine.Reporsitory.Service
{
    public  class DrugDetailsRepository : GenericRepository<LabManagementEntities, lmsDrugDetail>, IDrugDetailsRepository
    {
        public lmsDrugDetail GetSingle(int id)
        {
            var query = GetAll().FirstOrDefault(x => x.DRUGDETAILID == id);
            return query; ;
        }
    }
}
