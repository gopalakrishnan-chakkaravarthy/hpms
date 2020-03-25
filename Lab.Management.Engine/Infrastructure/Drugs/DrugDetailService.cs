using Lab.Management.Engine.Reporsitory.Interface;
using Lab.Management.Engine.Service.Drugs;
using Lab.Management.Entities;
using System;
using System.Collections.Generic;

namespace Lab.Management.Engine.Infrastructure.Drugs
{
    public class DrugDetailService : IDrugDetailService
    {
        private readonly IDrugDetailsRepository repository;
        public DrugDetailService(IDrugDetailsRepository repository)
        {
            this.repository = repository;
        }
        public IEnumerable<lmsDrugDetail> GetAll()
        {
            return repository.GetAll();
        }

        public lmsDrugDetail Get(int id)
        {
            if(id==0)
            {
                return new lmsDrugDetail();
            }
            return repository.GetSingle(id);
        }
        public bool Remove(int id)
        {
            try
            {
                var entity = repository.GetSingle(id);

                repository.Delete(entity);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Save(lmsDrugDetail entity)
        {
            try
            {
                if (entity.DRUGDETAILID > 0)
                {
                    repository.Edit(entity);
                }
                else
                {
                    repository.Add(entity);
                }
                repository.Save();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
