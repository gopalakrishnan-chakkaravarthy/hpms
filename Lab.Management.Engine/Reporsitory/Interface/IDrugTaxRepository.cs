using Lab.Management.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Lab.Management.Engine.Reporsitory.Interface
{
    public interface IDrugTaxRepository
    {
        IQueryable<lmsDrugsTax> GetAll();
        lmsDrugsTax GetSingle(int id);

        IQueryable<lmsDrugsTax> FindBy(Expression<Func<lmsDrugsTax, bool>> predicate);

        void Add(lmsDrugsTax entity);

        void Delete(lmsDrugsTax entity);

        void Edit(lmsDrugsTax entity);

        void Save();
    }
}
