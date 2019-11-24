using Lab.Management.Entities;
using System.Collections.Generic;

namespace Lab.Management.Engine.Service
{
    public interface IDeliveryIndication
    {
        lmsDeliveryIndication GetById(int id);

        IList<lmsDeliveryIndication> GetAll(int id = 0, string filterDate = "");

        int Save(lmsDeliveryIndication data);

        int Delete(int id);
    }
}
