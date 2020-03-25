using Lab.Management.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Lab.Management.Engine.Reporsitory.Interface
{
    public interface ITaxRepository
    {
        IQueryable<lmsTaxMaster> GetAll();

        lmsTaxMaster GetSingle(int id);

        IQueryable<lmsTaxMaster> FindBy(Expression<Func<lmsTaxMaster, bool>> predicate);

        void Add(lmsTaxMaster entity);

        void Delete(lmsTaxMaster entity);

        void Edit(lmsTaxMaster entity);

        void Save();
    }
}
