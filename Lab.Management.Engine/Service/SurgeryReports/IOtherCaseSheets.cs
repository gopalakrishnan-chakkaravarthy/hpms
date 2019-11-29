using Lab.Management.Entities;
using System.Collections.Generic;

namespace Lab.Management.Engine.Service
{
    public interface IOtherCaseSheets
    {
        lmsOtherCaseSheet GetById(int id);

        IList<lmsOtherCaseSheet> GetAll(string filterDate = "");

        int Save(lmsOtherCaseSheet data);

        int Delete(int id);
    }
}
