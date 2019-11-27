using Lab.Management.Entities;
using System.Collections.Generic;

namespace Lab.Management.Engine.Service
{
    public interface ISurgeryNotes
    {
        lmsSurgeryNote GetById(int id);

        IList<lmsSurgeryNote> GetAll(string filterDate = "");

        int Save(lmsSurgeryNote data);

        int Delete(int id);
    }
}
