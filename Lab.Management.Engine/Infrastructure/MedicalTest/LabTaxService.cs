using Lab.Management.Engine.Models;
using Lab.Management.Engine.Reporsitory.Interface;
using Lab.Management.Engine.Service.MedicalTest;
using Lab.Management.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Lab.Management.Engine.Infrastructure.MedicalTest
{
    public class LabTaxService : ILabTaxService
    {
        private readonly ILabTaxRepository labTaxRepository;
        public LabTaxService(ILabTaxRepository labTaxRepository)
        {
            this.labTaxRepository = labTaxRepository;
        }

        public lmsLabTax Get(int id)
        {
            return labTaxRepository.GetSingle(id);
        }

        public List<double?> GetTaxesPercentByTestId(int testId)
        {
            var allTestTax = labTaxRepository.GetAll().Where(x => x.TESTID == testId);
            var allTaxes = allTestTax.Select(x => x.lmsTaxMaster.PERCENTAGE).ToList();
            return allTaxes;
        }

        public IEnumerable<LabTaxResponse> GetTaxForTest(int testId)
        {
            var allDrugTax = labTaxRepository.GetAll().Where(x => x.TESTID == testId);
            if (!allDrugTax.Any())
            {
                return new List<LabTaxResponse>();
            }
            var result = allDrugTax.ToList().Select(x =>

                new LabTaxResponse { LTaxId = x.LTAXID, TestId = x.TESTID.Value, Name = $"{x.lmsTaxMaster.TAXNAME} - {x.lmsTaxMaster.PERCENTAGE}" }
            );
            return result;
        }

        public bool IsExists(int testId, int taxId)
        {
            var hasDrugTax = labTaxRepository.GetAll().Any(x => x.TESTID == testId
            && x.TAXID == taxId);
            return hasDrugTax;
        }

        public bool Remove(int id)
        {
            var entity = labTaxRepository.GetSingle(id);

            labTaxRepository.Delete(entity);
            return true;
        }

        public bool Save(LabTaxRequest labTaxRequest)
        {
            var entity = new lmsLabTax { TESTID = labTaxRequest.TestId, TAXID = labTaxRequest.TaxId };
            labTaxRepository.Add(entity);
            labTaxRepository.Save();
            return true;
        }
    }
}
