using Lab.Management.Entities;
using System.Collections.Generic;

namespace LabManagement.System.Models
{
    public class LaboratoryResultGroup
    {
        public string GroupName { get; set; }
        public IEnumerable<lmsLaboratoryBillingDetail> lmsLaboratoryBillingDetails { get; set; }
    }
}
