using Lab.Management.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Lab.Management.Engine.Reporsitory.Interface
{
    public interface IDrugDetailsRepository
    {
        IQueryable<lmsDrugDetail> GetAll();

        lmsDrugDetail GetSingle(int id);

        IQueryable<lmsDrugDetail> FindBy(Expression<Func<lmsDrugDetail, bool>> predicate);

        void Add(lmsDrugDetail entity);

        void Delete(lmsDrugDetail entity);

        void Edit(lmsDrugDetail entity);

        void Save();
    }
}
