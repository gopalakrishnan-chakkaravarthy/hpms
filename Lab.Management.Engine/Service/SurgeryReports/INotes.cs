using Lab.Management.Entities;
using System.Collections.Generic;

namespace Lab.Management.Engine.Service
{
    public interface INotes
    {
        lmsNote GetById(int id);

        IList<lmsNote> GetAll(int id = 0, string filterDate = "");

        int Save(lmsNote data);

        int Delete(int id);
    }
}
