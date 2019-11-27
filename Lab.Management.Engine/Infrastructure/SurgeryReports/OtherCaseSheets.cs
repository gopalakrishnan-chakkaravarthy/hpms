using Lab.Management.Engine.Service;
using Lab.Management.Entities;
using Lab.Management.Logger;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Lab.Management.Engine.Infrastructure
{
    public class OtherCaseSheets : IOtherCaseSheets
    {
        private LabManagementEntities _objLabManagementEntities;
        private readonly IAppLogger _objIAppLogger;
        public OtherCaseSheets(LabManagementEntities objLabManagementEntities, IAppLogger objIAppLogger)
        {
            _objLabManagementEntities = objLabManagementEntities;
            _objIAppLogger = objIAppLogger;
        }

        public int Delete(int id)
        {
            var resultFlag = 0;
            try
            {
                var deleteObject = _objLabManagementEntities.lmsOtherCaseSheets.FirstOrDefault(x => x.OCSID == id);
                var detail = _objLabManagementEntities.lmsOtherCaseSheets.Where(x => x.OCSID == id);
                _objLabManagementEntities.lmsOtherCaseSheets.RemoveRange(detail);
                _objLabManagementEntities.lmsOtherCaseSheets.Remove(deleteObject);
                _objLabManagementEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                resultFlag = -1;
                _objIAppLogger.LogError(ex);
            }

            return resultFlag;
        }

        public IList<lmsOtherCaseSheet> GetAll(int id = 0, string filterDate = "")
        {
            try
            {
                var queryDate = Convert.ToDateTime(filterDate).Date;
                var resultDetails = _objLabManagementEntities.lmsOtherCaseSheets.Where(bt => bt.OCSID == id);
                return resultDetails.Any() ? resultDetails.OrderByDescending(x => x.OCSID).ToList()
                    : new List<lmsOtherCaseSheet>();
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public lmsOtherCaseSheet GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new lmsOtherCaseSheet();
                }
                var resultDetails = _objLabManagementEntities.lmsOtherCaseSheets.FirstOrDefault(dt => dt.OCSID == id);
                return resultDetails;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public int Save(lmsOtherCaseSheet data)
        {
            var resultId = 0;
            try
            {
                if (data.OCSID > 0)
                {
                    _objLabManagementEntities.lmsOtherCaseSheets.Attach(data);
                    _objLabManagementEntities.Entry(data).State = EntityState.Modified;
                    _objLabManagementEntities.SaveChanges();
                    return data.OCSID;
                }
                _objLabManagementEntities.lmsOtherCaseSheets.Add(data);
                _objLabManagementEntities.SaveChanges();
                var result = _objLabManagementEntities.lmsOtherCaseSheets.ToList().LastOrDefault();
                resultId = result.OCSID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }

            return resultId;
        }
    }
}
