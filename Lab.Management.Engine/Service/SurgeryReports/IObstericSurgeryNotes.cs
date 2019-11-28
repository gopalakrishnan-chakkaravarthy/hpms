﻿using Lab.Management.Entities;
using System.Collections.Generic;

namespace Lab.Management.Engine.Service
{
    public interface IObstericSurgeryNotes
    {
        lmsObstericSurgeryNote GetById(int id);

        IList<lmsObstericSurgeryNote> GetAll(string filterDate = "");

        int Save(lmsObstericSurgeryNote data);

        int Delete(int id);
    }
}
