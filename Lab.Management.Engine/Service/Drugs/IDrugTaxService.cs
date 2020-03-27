using Lab.Management.Engine.Models;
using Lab.Management.Entities;
using System.Collections.Generic;

namespace Lab.Management.Engine.Service.Drugs
{
    public interface IDrugTaxService
    {
        bool Save(DrugTaxRequest drugTaxRequest);

        IEnumerable<DrugTaxResponse> GetTaxForDrugs(int drugId);
        List<double?> GetTaxesPercentByDrugId(int drugId);
        bool IsExists(int drugId,int taxId);
        lmsDrugsTax Get(int id);

        bool Remove(int id);
    }
}
