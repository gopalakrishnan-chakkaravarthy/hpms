using Lab.Management.Entities;
using System.Collections.Generic;

namespace Lab.Management.Engine.Service
{
    public interface IObstericAdmissionSheetReports
    {
        lmsObstericAdmissionSheet GetById(int id);

        IList<lmsObstericAdmissionSheet> GetAll(string filterDate = "");

        int Save(lmsObstericAdmissionSheet data);

        int Delete(int id);
    }
}
