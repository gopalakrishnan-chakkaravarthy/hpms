using Lab.Management.Engine.Service;
using Lab.Management.Entities;
using Lab.Management.Logger;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Lab.Management.Engine.Infrastructure
{
    public class LabourNotes : ILabourNotes
    {
        private LabManagementEntities _objLabManagementEntities;
        private readonly IAppLogger _objIAppLogger;
        public LabourNotes(LabManagementEntities objLabManagementEntities, IAppLogger objIAppLogger)
        {
            _objLabManagementEntities = objLabManagementEntities;
            _objIAppLogger = objIAppLogger;
        }

        public int Delete(int id)
        {
            var resultFlag = 0;
            try
            {
                var deleteObject = _objLabManagementEntities.lmsLabourNotes.FirstOrDefault(x => x.LNID == id);
                var detail = _objLabManagementEntities.lmsLabourNotes.Where(x => x.LNID == id);
                _objLabManagementEntities.lmsLabourNotes.RemoveRange(detail);
                _objLabManagementEntities.lmsLabourNotes.Remove(deleteObject);
                _objLabManagementEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                resultFlag = -1;
                _objIAppLogger.LogError(ex);
            }

            return resultFlag;
        }

        public IList<lmsLabourNote> GetAll(string filterDate = "")
        {
            try
            {
                var queryDate = Convert.ToDateTime(filterDate).Date;
                var resultDetails = _objLabManagementEntities.lmsLabourNotes.Where(bt => bt.CREATEDATE == queryDate);
                return resultDetails.Any() ? resultDetails.OrderByDescending(x => x.LNID).ToList()
                    : new List<lmsLabourNote>();
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public lmsLabourNote GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new lmsLabourNote();
                }
                var resultDetails = _objLabManagementEntities.lmsLabourNotes.FirstOrDefault(dt => dt.LNID == id);
                return resultDetails;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public int Save(lmsLabourNote data)
        {
            var resultId = 0;
            try
            {
                if (data.LNID > 0)
                {
                    _objLabManagementEntities.lmsLabourNotes.Attach(data);
                    _objLabManagementEntities.Entry(data).State = EntityState.Modified;
                    _objLabManagementEntities.SaveChanges();
                    return data.LNID;
                }
                _objLabManagementEntities.lmsLabourNotes.Add(data);
                _objLabManagementEntities.SaveChanges();
                var result = _objLabManagementEntities.lmsLabourNotes.ToList().LastOrDefault();
                resultId = result.LNID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }

            return resultId;
        }
    }
}
