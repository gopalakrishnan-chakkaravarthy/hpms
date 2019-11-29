using Lab.Management.Entities;
using System.Collections.Generic;

namespace Lab.Management.Engine.Service
{
    public interface ILabourNotes
    {
        lmsLabourNote GetById(int id);

        IList<lmsLabourNote> GetAll(string filterDate = "");

        int Save(lmsLabourNote data);

        int Delete(int id);
    }
}
