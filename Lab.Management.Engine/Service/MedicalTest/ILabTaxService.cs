using Lab.Management.Engine.Models;
using Lab.Management.Entities;
using System.Collections.Generic;

namespace Lab.Management.Engine.Service.MedicalTest
{
    public interface ILabTaxService
    {
        bool Save(LabTaxRequest labTaxRequest);

        IEnumerable<LabTaxResponse> GetTaxForTest(int testId);
        List<double?> GetTaxesPercentByTestId(int testId);
        bool IsExists(int testId, int taxId);
        lmsLabTax Get(int id);

        bool Remove(int id);
    }
}
