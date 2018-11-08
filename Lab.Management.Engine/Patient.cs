using Lab.Management.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.Management.Logger;
using Lab.Management.Engine.Utils;
using System.Data.Entity;
namespace Lab.Management.Engine
{
    public class Patient : IPatient
    {
        private LabManagementEntities _objLabManagementEntities;
        private readonly IAppLogger _objIAppLogger;
        public Patient(LabManagementEntities objLabManagementEntities, IAppLogger objIAppLogger)
        {
            _objLabManagementEntities = objLabManagementEntities;
            _objIAppLogger = objIAppLogger;
        }
        public lmsPatientRegistration GetPatientDetailsById(int PatientId)
        {
            try
            {
                if (PatientId == 0)
                {
                    var newPatient = new lmsPatientRegistration();
                    newPatient.ISDISCHARGED = false;
                    return newPatient;
                }
                var resultDetails = _objLabManagementEntities.lmsPatientRegistrations.FirstOrDefault(dt => dt.PATIENTID == PatientId);
                resultDetails.ISDISCHARGED = resultDetails.ISDISCHARGED == null ? false : resultDetails.ISDISCHARGED.Value;
                return resultDetails;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
            finally
            {

            }

        }
        public IList<lmsPatientRegistration> GetAllPatient(string patientType, bool includeAll = false)
        {
            try
            {

                var resultDetails = _objLabManagementEntities.lmsPatientRegistrations.Select(x => x);
                return includeAll ? resultDetails.OrderByDescending(x => x.PATIENTID).ToList() : resultDetails.Where(x => x.PATIENTTYPE == patientType).OrderByDescending(x => x.PATIENTID).ToList();
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
            finally
            {

            }
        }
        public int SavePatient(lmsPatientRegistration objlmsPatientRegistrations)
        {
            var resultId = 0;
            try
            {
                if (objlmsPatientRegistrations.PATIENTID > 0)
                {
                    _objLabManagementEntities.lmsPatientRegistrations.Attach(objlmsPatientRegistrations);
                    _objLabManagementEntities.Entry(objlmsPatientRegistrations).State = EntityState.Modified;
                }
                else
                {
                    _objLabManagementEntities.lmsPatientRegistrations.Add(objlmsPatientRegistrations);
                }


                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsPatientRegistrations.AsEnumerable().LastOrDefault().PATIENTID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }
            finally
            {

            }
            return resultId;
        }
        public int DeletePatient(int PatientId)
        {
            var resultFlag = 0;
            try
            {
                var PatientObject = _objLabManagementEntities.lmsPatientRegistrations.FirstOrDefault(x => x.PATIENTID == PatientId);
                _objLabManagementEntities.lmsPatientRegistrations.Remove(PatientObject);
                _objLabManagementEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                resultFlag = -1;
                _objIAppLogger.LogError(ex);
            }
            finally
            {

            }
            return resultFlag;
        }
        public lmsOutPatientMaster GetOutPatientMasterById(int PatientId)
        {
            try
            {
                if (PatientId == 0)
                {
                    var newPatient = new lmsOutPatientMaster();

                    return newPatient;
                }
                var resultDetails = _objLabManagementEntities.lmsOutPatientMasters.FirstOrDefault(dt => dt.OPMASTERID == PatientId);
                return resultDetails;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
            finally
            {

            }

        }
        public IList<lmsOutPatientMaster> GetAllOutPatient()
        {
            try
            {
                var resultDetails = _objLabManagementEntities.lmsOutPatientMasters.Select(x => x);
                return resultDetails.ToList();
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return new List<lmsOutPatientMaster>();
            }
            finally
            {

            }
        }
        public int SaveOutPatient(lmsOutPatientMaster objlmsPatientRegistrations)
        {
            var resultId = 0;
            try
            {
                if (objlmsPatientRegistrations.OPMASTERID > 0)
                {
                    _objLabManagementEntities.lmsOutPatientMasters.Attach(objlmsPatientRegistrations);
                    _objLabManagementEntities.Entry(objlmsPatientRegistrations).State = EntityState.Modified;
                }
                else
                {
                    _objLabManagementEntities.lmsOutPatientMasters.Add(objlmsPatientRegistrations);
                }

                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsOutPatientMasters.AsEnumerable().LastOrDefault().OPMASTERID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }
            finally
            {

            }
            return resultId;
        }
        public int DeleteOutPatient(int PatientId)
        {
            var resultFlag = 0;
            try
            {
                var PatientObject = _objLabManagementEntities.lmsOutPatientMasters.FirstOrDefault(x => x.OPMASTERID == PatientId);
                var patientDetails = _objLabManagementEntities.lmsOutPatientDetails.Where(x => x.OPMASTERID == PatientObject.OPMASTERID);
                if (patientDetails.Any())
                {
                    _objLabManagementEntities.lmsOutPatientDetails.RemoveRange(patientDetails);
                }

                _objLabManagementEntities.lmsOutPatientMasters.Remove(PatientObject);
                _objLabManagementEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                resultFlag = -1;
                _objIAppLogger.LogError(ex);
            }
            finally
            {

            }
            return resultFlag;
        }

        public lmsOutPatientDetail GetOutPatientDetailsById(int PatientId)
        {
            try
            {
                if (PatientId == 0)
                {
                    var newPatient = new lmsOutPatientDetail();

                    return newPatient;
                }
                var resultDetails = _objLabManagementEntities.lmsOutPatientDetails.FirstOrDefault(dt => dt.OPDID == PatientId);
                return resultDetails;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }


        }
        public IList<lmsOutPatientDetail> GetAllOutPatientDetails(int patientDetailsId)
        {
            try
            {
                var resultDetails = _objLabManagementEntities.lmsOutPatientDetails.Where(x => x.OPMASTERID == patientDetailsId);
                return resultDetails.OrderByDescending(x => x.OPDID).ToList();
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }

        }
        public int SaveOutPatientDetail(lmsOutPatientDetail objlmsPatientRegistrations)
        {
            var resultId = 0;
            try
            {
                if (objlmsPatientRegistrations.OPDID > 0)
                {
                    _objLabManagementEntities.lmsOutPatientDetails.Attach(objlmsPatientRegistrations);
                    _objLabManagementEntities.Entry(objlmsPatientRegistrations).State = EntityState.Modified;
                }
                else
                {
                    _objLabManagementEntities.lmsOutPatientDetails.Add(objlmsPatientRegistrations);
                }


                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsOutPatientDetails.AsEnumerable().LastOrDefault().OPDID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }

            return resultId;
        }
        public int DeleteOutPatientDetail(int PatientId)
        {
            var resultFlag = 0;
            try
            {
                var patientDetails = _objLabManagementEntities.lmsOutPatientDetails.FirstOrDefault(x => x.OPDID == PatientId);
                _objLabManagementEntities.lmsOutPatientDetails.Remove(patientDetails);
                _objLabManagementEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                resultFlag = -1;
                _objIAppLogger.LogError(ex);
            }

            return resultFlag;
        }

        public IList<usp_GetPatientDdlForBilling_Result> GetPatientDdl()
        {
            return _objLabManagementEntities.usp_GetPatientDdlForBilling().ToList();
        }
    }
}
