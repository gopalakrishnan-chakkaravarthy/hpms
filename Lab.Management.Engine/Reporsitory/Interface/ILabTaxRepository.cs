using Lab.Management.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Lab.Management.Engine.Reporsitory.Interface
{
    public interface ILabTaxRepository
    {
        IQueryable<lmsLabTax> GetAll();
        lmsLabTax GetSingle(int id);

        IQueryable<lmsLabTax> FindBy(Expression<Func<lmsLabTax, bool>> predicate);

        void Add(lmsLabTax entity);

        void Delete(lmsLabTax entity);

        void Edit(lmsLabTax entity);

        void Save();
    }
}
