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
    public class SurgeryNotes : ISurgeryNotes
    {
        private LabManagementEntities _objLabManagementEntities;
        private readonly IAppLogger _objIAppLogger;
        public SurgeryNotes(LabManagementEntities objLabManagementEntities, IAppLogger objIAppLogger)
        {
            _objLabManagementEntities = objLabManagementEntities;
            _objIAppLogger = objIAppLogger;
        }

        public int Delete(int id)
        {
            var resultFlag = 0;
            try
            {
                var deleteObject = _objLabManagementEntities.lmsSurgeryNotes.FirstOrDefault(x => x.SNID == id);
                var detail = _objLabManagementEntities.lmsSurgeryNotes.Where(x => x.SNID == id);
                _objLabManagementEntities.lmsSurgeryNotes.RemoveRange(detail);
                _objLabManagementEntities.lmsSurgeryNotes.Remove(deleteObject);
                _objLabManagementEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                resultFlag = -1;
                _objIAppLogger.LogError(ex);
            }

            return resultFlag;
        }

        public IList<lmsSurgeryNote> GetAll(string filterDate = "")
        {
            try
            {
                var queryDate = Convert.ToDateTime(filterDate).Date;
                var resultDetails = _objLabManagementEntities.lmsSurgeryNotes.Where(bt => EntityFunctions.TruncateTime(bt.CREDATEDDATE.Value) == queryDate);
                return resultDetails.Any() ? resultDetails.OrderByDescending(x => x.SNID).ToList()
                    : new List<lmsSurgeryNote>();
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public lmsSurgeryNote GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new lmsSurgeryNote();
                }
                var resultDetails = _objLabManagementEntities.lmsSurgeryNotes.FirstOrDefault(dt => dt.SNID == id);
                return resultDetails;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public int Save(lmsSurgeryNote data)
        {
            var resultId = 0;
            try
            {
                if (data.SNID > 0)
                {
                    _objLabManagementEntities.lmsSurgeryNotes.Attach(data);
                    _objLabManagementEntities.Entry(data).State = EntityState.Modified;
                    _objLabManagementEntities.SaveChanges();
                    return data.SNID;
                }
                _objLabManagementEntities.lmsSurgeryNotes.Add(data);
                _objLabManagementEntities.SaveChanges();
                var result = _objLabManagementEntities.lmsSurgeryNotes.ToList().LastOrDefault();
                resultId = result.SNID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }

            return resultId;
        }
    }
}
