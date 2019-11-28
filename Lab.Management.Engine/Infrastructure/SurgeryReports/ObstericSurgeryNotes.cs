using Lab.Management.Engine.Service;
using Lab.Management.Entities;
using Lab.Management.Logger;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Lab.Management.Engine.Infrastructure
{
    public class ObstericSurgeryNotes : IObstericSurgeryNotes
    {
        private LabManagementEntities _objLabManagementEntities;
        private readonly IAppLogger _objIAppLogger;
        public ObstericSurgeryNotes(LabManagementEntities objLabManagementEntities, IAppLogger objIAppLogger)
        {
            _objLabManagementEntities = objLabManagementEntities;
            _objIAppLogger = objIAppLogger;
        }

        public int Delete(int id)
        {
            var resultFlag = 0;
            try
            {
                var deleteObject = _objLabManagementEntities.lmsObstericSurgeryNotes.FirstOrDefault(x => x.OSNID == id);
                var detail = _objLabManagementEntities.lmsObstericSurgeryNotes.Where(x => x.OSNID == id);
                _objLabManagementEntities.lmsObstericSurgeryNotes.RemoveRange(detail);
                _objLabManagementEntities.lmsObstericSurgeryNotes.Remove(deleteObject);
                _objLabManagementEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                resultFlag = -1;
                _objIAppLogger.LogError(ex);
            }

            return resultFlag;
        }

        public IList<lmsObstericSurgeryNote> GetAll(string filterDate = "")
        {
            try
            {
                var queryDate = Convert.ToDateTime(filterDate).Date;
                var resultDetails = _objLabManagementEntities.lmsObstericSurgeryNotes.Where(bt => bt.lmsObstericAdmissionSheet.CREATEDDATE == queryDate);
                return resultDetails.Any() ? resultDetails.OrderByDescending(x => x.OSNID).ToList()
                    : new List<lmsObstericSurgeryNote>();
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public lmsObstericSurgeryNote GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new lmsObstericSurgeryNote();
                }
                var resultDetails = _objLabManagementEntities.lmsObstericSurgeryNotes.FirstOrDefault(dt => dt.OSNID == id);
                return resultDetails;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public int Save(lmsObstericSurgeryNote data)
        {
            var resultId = 0;
            try
            {
                if (data.OSNID > 0)
                {
                    _objLabManagementEntities.lmsObstericSurgeryNotes.Attach(data);
                    _objLabManagementEntities.Entry(data).State = EntityState.Modified;
                    _objLabManagementEntities.SaveChanges();
                    return data.OSNID;
                }
                _objLabManagementEntities.lmsObstericSurgeryNotes.Add(data);
                _objLabManagementEntities.SaveChanges();
                var result = _objLabManagementEntities.lmsObstericSurgeryNotes.ToList().LastOrDefault();
                resultId = result.OSNID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }

            return resultId;
        }
    }
}
