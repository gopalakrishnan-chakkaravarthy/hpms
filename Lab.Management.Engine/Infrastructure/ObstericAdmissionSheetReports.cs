using Lab.Management.Engine.Service;
using Lab.Management.Entities;
using Lab.Management.Logger;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace Lab.Management.Engine.Infrastructure
{
    public class ObstericAdmissionSheetReports : IObstericAdmissionSheetReports
    {
        private LabManagementEntities _objLabManagementEntities;
        private readonly IAppLogger _objIAppLogger;
        public ObstericAdmissionSheetReports(LabManagementEntities objLabManagementEntities, IAppLogger objIAppLogger)
        {
            _objLabManagementEntities = objLabManagementEntities;
            _objIAppLogger = objIAppLogger;
        }

        public lmsObstericAdmissionSheet GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new lmsObstericAdmissionSheet();
                }
                var resultDetails = _objLabManagementEntities.lmsObstericAdmissionSheets.FirstOrDefault(dt => dt.OASID == id);
                return resultDetails;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public IList<lmsObstericAdmissionSheet> GetAll(int id = 0, string filterDate = "")
        {
            try
            {
                var queryDate = Convert.ToDateTime(filterDate).Date;
                var resultDetails = _objLabManagementEntities.lmsObstericAdmissionSheets.Where(bt => bt.CREATEDDATE.HasValue
                && EntityFunctions.TruncateTime(bt.CREATEDDATE.Value) == queryDate);
                return resultDetails.Any() ? resultDetails.OrderByDescending(x => x.OASID).ToList()
                    : new List<lmsObstericAdmissionSheet>();
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public int Save(lmsObstericAdmissionSheet data)
        {
            var resultId = 0;
            try
            {
                if (data.OASID > 0)
                {
                    _objLabManagementEntities.lmsObstericAdmissionSheets.Attach(data);
                    _objLabManagementEntities.Entry(data).State = EntityState.Modified;
                    _objLabManagementEntities.SaveChanges();
                    return data.OASID;
                }
                _objLabManagementEntities.lmsObstericAdmissionSheets.Add(data);
                _objLabManagementEntities.SaveChanges();
                var result = _objLabManagementEntities.lmsObstericAdmissionSheets.ToList().LastOrDefault();
                resultId = result.OASID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }

            return resultId;
        }

        public int Delete(int id)
        {
            var resultFlag = 0;
            try
            {
                var deleteObject = _objLabManagementEntities.lmsObstericAdmissionSheets.FirstOrDefault(x => x.OASID == id);
                var details = _objLabManagementEntities.lmsObstericAdmissionSheets.Where(x => x.OASID == id);
                _objLabManagementEntities.lmsObstericAdmissionSheets.RemoveRange(details);
                _objLabManagementEntities.lmsObstericAdmissionSheets.Remove(deleteObject);
                _objLabManagementEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                resultFlag = -1;
                _objIAppLogger.LogError(ex);
            }

            return resultFlag;
        }
    }
}
