using Lab.Management.Engine.Models;
using Lab.Management.Engine.QueryBuilder;
using Lab.Management.Engine.Reporsitory.Interface;
using Lab.Management.Engine.Service.Tax;
using Lab.Management.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab.Management.Engine.Infrastructure.Tax
{
    public class TaxService : ITaxService
    {
        private readonly ITaxRepository taxRepository;
        public TaxService(ITaxRepository taxRepository)
        {
            this.taxRepository = taxRepository;
        }
        public IEnumerable<lmsTaxMaster> GetAll()
        {
            return taxRepository.GetAll().ToList();
        }
        public IList<DropDown> GetTaxList()
        {
            var allText = taxRepository.GetAll().Where(x => x.ISACTIVE.HasValue && x.ISACTIVE.Value).ToList();
            if(!allText.Any())
            {
                return new List<DropDown>();
            }
            var ddlTax = allText.Select(x => new DropDown { Key = x.TAXID.ToString(), Value = $"{x.TAXNAME} - {x.PERCENTAGE}" });
            return ddlTax.ToList();
        }
        public lmsTaxMaster Get(int id)
        {
            if(id==0)
            {
                return new lmsTaxMaster { ISACTIVE = true };
            }
            return taxRepository.GetSingle(id);
        }
        public int GetIdByText(string taxName)
        {
            var predicate = PredicateBuilder.True<lmsTaxMaster>();
            var item= taxRepository.FindBy(predicate.And(x => x.TAXNAME==taxName)).ToList();
            return item.Any() ? item.Single().TAXID : 0;
        }
        public bool Remove(int id)
        {
            try
            {
                var entity = taxRepository.GetSingle(id);

                taxRepository.Delete(entity);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Save(lmsTaxMaster entity)
        {
            try
            {
                if (entity.TAXID>0)
                {
                    taxRepository.Edit(entity);
                }
                else
                {
                    taxRepository.Add(entity);
                }
                taxRepository.Save();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
