using Lab.Management.Engine.Service;
using Lab.Management.Entities;
using Lab.Management.Logger;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Lab.Management.Engine.Infrastructure
{
    public class Notes : INotes
    {
        private LabManagementEntities _objLabManagementEntities;
        private readonly IAppLogger _objIAppLogger;
        public Notes(LabManagementEntities objLabManagementEntities, IAppLogger objIAppLogger)
        {
            _objLabManagementEntities = objLabManagementEntities;
            _objIAppLogger = objIAppLogger;
        }

        public int Delete(int id)
        {
            var resultFlag = 0;
            try
            {
                var deleteObject = _objLabManagementEntities.lmsNotes.FirstOrDefault(x => x.OCSID == id);
                var detail = _objLabManagementEntities.lmsNotes.Where(x => x.OCSID == id);
                _objLabManagementEntities.lmsNotes.RemoveRange(detail);
                _objLabManagementEntities.lmsNotes.Remove(deleteObject);
                _objLabManagementEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                resultFlag = -1;
                _objIAppLogger.LogError(ex);
            }

            return resultFlag;
        }

        public IList<lmsNote> GetAll(int id = 0, string filterDate = "")
        {
            try
            {
                var queryDate = Convert.ToDateTime(filterDate).Date;
                var resultDetails = _objLabManagementEntities.lmsNotes.Where(bt => bt.OCSID == id);
                return resultDetails.Any() ? resultDetails.OrderByDescending(x => x.OCSID).ToList()
                    : new List<lmsNote>();
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public lmsNote GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new lmsNote();
                }
                var resultDetails = _objLabManagementEntities.lmsNotes.FirstOrDefault(dt => dt.OCSID == id);
                return resultDetails;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public int Save(lmsNote data)
        {
            var resultId = 0;
            try
            {
                if (data.ANID > 0)
                {
                    _objLabManagementEntities.lmsNotes.Attach(data);
                    _objLabManagementEntities.Entry(data).State = EntityState.Modified;
                    _objLabManagementEntities.SaveChanges();
                    return data.ANID;
                }
                _objLabManagementEntities.lmsNotes.Add(data);
                _objLabManagementEntities.SaveChanges();
                var result = _objLabManagementEntities.lmsNotes.ToList().LastOrDefault();
                resultId = result.ANID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }

            return resultId;
        }
    }
}
