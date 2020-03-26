using Lab.Management.Engine.Models;
using Lab.Management.Engine.Reporsitory.Interface;
using Lab.Management.Engine.Service.Drugs;
using Lab.Management.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Lab.Management.Engine.Infrastructure.Drugs
{
    public class DrugTaxService : IDrugTaxService
    {
        private readonly IDrugTaxRepository drugTaxRepository;
        public DrugTaxService(IDrugTaxRepository drugTaxRepository)
        {
            this.drugTaxRepository = drugTaxRepository;
        }

        public lmsDrugsTax Get(int id)
        {
            return drugTaxRepository.GetSingle(id);
        }

        public IEnumerable<DrugTaxResponse> GetTaxForDrugs(int drugId)
        {
            var allDrugTax = drugTaxRepository.GetAll().Where(x => x.DRUGID == drugId);
            if (!allDrugTax.Any())
            {
                return new List<DrugTaxResponse>();
            }
            var result = allDrugTax.ToList().Select(x =>

                new DrugTaxResponse { DTaxId = x.DTAXID, DrugId = x.DRUGID.Value, Name = $"{x.lmsTaxMaster.TAXNAME} - {x.lmsTaxMaster.PERCENTAGE}" }
            );
            return result;
        }

        public bool IsExists(int drugId, int taxId)
        {
            var hasDrugTax = drugTaxRepository.GetAll().Any(x => x.DRUGID == drugId
             && x.TAXID == taxId);
            return hasDrugTax;
        }

        public bool Remove(int id)
        {
            var entity = drugTaxRepository.GetSingle(id);

            drugTaxRepository.Delete(entity);
            return true;
        }

        public bool Save(DrugTaxRequest drugTaxRequest )
        {
            var entity = new lmsDrugsTax { DRUGID = drugTaxRequest.DrugId, TAXID = drugTaxRequest.TaxId };
            drugTaxRepository.Add(entity);
            drugTaxRepository.Save();
            return true;
        }
    }
}
