using Lab.Management.Engine.Service;
using Lab.Management.Entities;
using Lab.Management.Logger;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Lab.Management.Engine.Infrastructure
{
    public class DeliveryIndication : IDeliveryIndication
    {
        private LabManagementEntities _objLabManagementEntities;
        private readonly IAppLogger _objIAppLogger;
        public DeliveryIndication(LabManagementEntities objLabManagementEntities, IAppLogger objIAppLogger)
        {
            _objLabManagementEntities = objLabManagementEntities;
            _objIAppLogger = objIAppLogger;
        }

        public int Delete(int id)
        {
            var resultFlag = 0;
            try
            {
                var deleteObject = _objLabManagementEntities.lmsDeliveryIndications.FirstOrDefault(x => x.OASID == id);
                var detail = _objLabManagementEntities.lmsDeliveryIndications.Where(x => x.OASID == id);
                _objLabManagementEntities.lmsDeliveryIndications.RemoveRange(detail);
                _objLabManagementEntities.lmsDeliveryIndications.Remove(deleteObject);
                _objLabManagementEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                resultFlag = -1;
                _objIAppLogger.LogError(ex);
            }

            return resultFlag;
        }

        public IList<lmsDeliveryIndication> GetAll(int id = 0, string filterDate = "")
        {
            try
            {
                var queryDate = Convert.ToDateTime(filterDate).Date;
                var resultDetails = _objLabManagementEntities.lmsDeliveryIndications.Where(bt => bt.OASID == id);
                return resultDetails.Any() ? resultDetails.OrderByDescending(x => x.DIID).ToList()
                    : new List<lmsDeliveryIndication>();
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public lmsDeliveryIndication GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new lmsDeliveryIndication();
                }
                var resultDetails = _objLabManagementEntities.lmsDeliveryIndications.FirstOrDefault(dt => dt.OASID == id);
                return resultDetails;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public int Save(lmsDeliveryIndication data)
        {
            var resultId = 0;
            try
            {
                if (data.DIID > 0)
                {
                    _objLabManagementEntities.lmsDeliveryIndications.Attach(data);
                    _objLabManagementEntities.Entry(data).State = EntityState.Modified;
                    _objLabManagementEntities.SaveChanges();
                    return data.DIID;
                }
                _objLabManagementEntities.lmsDeliveryIndications.Add(data);
                _objLabManagementEntities.SaveChanges();
                var result = _objLabManagementEntities.lmsDeliveryIndications.ToList().LastOrDefault();
                resultId = result.DIID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }

            return resultId;
        }
    }
}
