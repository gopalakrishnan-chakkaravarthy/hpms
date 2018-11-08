using Lab.Management.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.Management.Logger;
using Lab.Management.Engine.Utils;
using System.Data.Entity;
using Lab.Management.Common;
using Lab.Management.Engine.Models;
namespace Lab.Management.Engine
{
    public class AdminOperations : IAdminOperations
    {
        private LabManagementEntities _objLabManagementEntities;
        private readonly IAppLogger _objIAppLogger;
        public AdminOperations(LabManagementEntities objLabManagementEntities, IAppLogger objIAppLogger)
        {
            _objLabManagementEntities = objLabManagementEntities;
            _objIAppLogger = objIAppLogger;
        }
        public usp_ValidateUser_Result ValidateUser(string userName, string password)
        {
            var isValidaUser = new usp_ValidateUser_Result();
            try
            {
                var resultDetails = _objLabManagementEntities.usp_ValidateUser(userName);
                isValidaUser = resultDetails.FirstOrDefault(x => x.LOGINPASSWORD == password);
                return isValidaUser;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return isValidaUser;
            }

        }
        public lmsCityMaster GetCityDetailsById(int cityId)
        {
            try
            {
                if (cityId == 0)
                {
                    return new lmsCityMaster();
                }
                var resultDetails = _objLabManagementEntities.lmsCityMasters.FirstOrDefault(x => x.CITYID == cityId);
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
        public IList<lmsCityMaster> GetAllCity()
        {
            try
            {

                var resultDetails = _objLabManagementEntities.lmsCityMasters.Select(x => x);
                return resultDetails.ToList();
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
        public int SaveCity(lmsCityMaster objCityMaster)
        {
            var resultId = 0;
            try
            {
                if (objCityMaster.CITYID > 0)
                {
                    _objLabManagementEntities.lmsCityMasters.Attach(objCityMaster);
                    _objLabManagementEntities.Entry(objCityMaster).State = EntityState.Modified;
                }
                else
                {
                    _objLabManagementEntities.lmsCityMasters.Add(objCityMaster);
                }
                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsCityMasters.AsEnumerable().LastOrDefault().CITYID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }

            return resultId;
        }
        public int DeleteCity(int cityId)
        {
            var resultFlag = 0;
            try
            {
                var cityObject = _objLabManagementEntities.lmsCityMasters.FirstOrDefault(x => x.CITYID == cityId);
                _objLabManagementEntities.lmsCityMasters.Remove(cityObject);
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
        public lmsStateMaster GetStateDetailsById(int StateId)
        {
            try
            {
                if (StateId == 0)
                {
                    return new lmsStateMaster();
                }
                var resultDetails = _objLabManagementEntities.lmsStateMasters.FirstOrDefault(x => x.STATEID == StateId);
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
        public IList<lmsStateMaster> GetAllState()
        {
            try
            {

                var resultDetails = _objLabManagementEntities.lmsStateMasters.Select(x => x);
                return resultDetails.ToList();
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
        public int SaveState(lmsStateMaster objStateMaster)
        {
            var resultId = 0;
            try
            {
                if (objStateMaster.STATEID > 0)
                {
                    _objLabManagementEntities.lmsStateMasters.Attach(objStateMaster);
                    _objLabManagementEntities.Entry(objStateMaster).State = EntityState.Modified;
                }
                else
                {
                    _objLabManagementEntities.lmsStateMasters.Add(objStateMaster);
                }
                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsStateMasters.AsEnumerable().LastOrDefault().STATEID;
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
        public int DeleteState(int StateId)
        {
            var resultFlag = 0;
            try
            {
                var StateObject = _objLabManagementEntities.lmsStateMasters.FirstOrDefault(x => x.STATEID == StateId);
                _objLabManagementEntities.lmsStateMasters.Remove(StateObject);
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
        public lmsRoleMaster GetRoleDetailsById(int RoleId)
        {
            try
            {
                if (RoleId == 0)
                {
                    return new lmsRoleMaster();
                }
                var resultDetails = _objLabManagementEntities.lmsRoleMasters.FirstOrDefault(x => x.ROLEID == RoleId);
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
        public IList<lmsRoleMaster> GetAllRole()
        {
            try
            {

                var resultDetails = _objLabManagementEntities.lmsRoleMasters.Select(x => x);
                return resultDetails.ToList();
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
        public int SaveRole(lmsRoleMaster objRoleMaster)
        {
            var resultId = 0;
            try
            {
                if (objRoleMaster.ROLEID > 0)
                {
                    _objLabManagementEntities.lmsRoleMasters.Attach(objRoleMaster);
                    _objLabManagementEntities.Entry(objRoleMaster).State = EntityState.Modified;
                }
                else
                {
                    _objLabManagementEntities.lmsRoleMasters.Add(objRoleMaster);
                }
                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsRoleMasters.AsEnumerable().LastOrDefault().ROLEID;
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
        public int DeleteRole(int RoleId)
        {
            var resultFlag = 0;
            try
            {
                var RoleObject = _objLabManagementEntities.lmsRoleMasters.FirstOrDefault(x => x.ROLEID == RoleId);
                _objLabManagementEntities.lmsRoleMasters.Remove(RoleObject);
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
        public lmsHospitalMaster GetHospitalDetailsById(int HospitalId)
        {
            try
            {
                if (HospitalId == 0)
                {
                    var newHospital = new lmsHospitalMaster();
                    newHospital.ISOCERTIFIED = true;
                    return newHospital;
                }
                var resultDetails = _objLabManagementEntities.lmsHospitalMasters.FirstOrDefault(x => x.HOSPITALID == HospitalId);
                resultDetails.ISOCERTIFIED = resultDetails.ISOCERTIFIED == null ? true : resultDetails.ISOCERTIFIED.Value;
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
        public IList<lmsHospitalMaster> GetAllHospital()
        {
            try
            {

                var resultDetails = _objLabManagementEntities.lmsHospitalMasters.Select(x => x);
                return resultDetails.ToList();
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
        public int SaveHospital(lmsHospitalMaster objHospitalMaster)
        {
            var resultId = 0;
            try
            {
                if (objHospitalMaster.HOSPITALID > 0)
                {
                    _objLabManagementEntities.lmsHospitalMasters.Attach(objHospitalMaster);
                    _objLabManagementEntities.Entry(objHospitalMaster).State = EntityState.Modified;
                }
                else
                {
                    _objLabManagementEntities.lmsHospitalMasters.Add(objHospitalMaster);
                }
                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsHospitalMasters.AsEnumerable().LastOrDefault().HOSPITALID;
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
        public int DeleteHospital(int HospitalId)
        {
            var resultFlag = 0;
            try
            {
                var RoleObject = _objLabManagementEntities.lmsHospitalMasters.FirstOrDefault(x => x.HOSPITALID == HospitalId);
                _objLabManagementEntities.lmsHospitalMasters.Remove(RoleObject);
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
        public lmsLoginRegistration GetUserDetailsById(int UserId)
        {
            try
            {
                if (UserId == 0)
                {
                    var newUser = new lmsLoginRegistration();
                    newUser.ISACTIVE = false;
                    return newUser;
                }
                var resultDetails = _objLabManagementEntities.lmsLoginRegistrations.FirstOrDefault(x => x.LOGINID == UserId);
                resultDetails.ISACTIVE = resultDetails.ISACTIVE == null || !resultDetails.ISACTIVE.HasValue ? true : resultDetails.ISACTIVE.Value;
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
        public IList<lmsLoginRegistration> GetAllUsers()
        {
            try
            {

                var resultDetails = _objLabManagementEntities.lmsLoginRegistrations.Select(x => x);
                return resultDetails.ToList();
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
        public int SaveUser(lmsLoginRegistration objlmsLoginRegistration)
        {
            var resultId = 0;
            try
            {
                if (objlmsLoginRegistration.LOGINID > 0)
                {
                    _objLabManagementEntities.lmsLoginRegistrations.Attach(objlmsLoginRegistration);
                    _objLabManagementEntities.Entry(objlmsLoginRegistration).State = EntityState.Modified;
                }
                else
                {
                    _objLabManagementEntities.lmsLoginRegistrations.Add(objlmsLoginRegistration);
                }
                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsLoginRegistrations.AsEnumerable().LastOrDefault().LOGINID;
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
        public int DeleteUser(int UserId)
        {
            var resultFlag = 0;
            try
            {
                var resultObject = _objLabManagementEntities.lmsLoginRegistrations.FirstOrDefault(x => x.LOGINID == UserId);
                _objLabManagementEntities.lmsLoginRegistrations.Remove(resultObject);
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

        public lmsDiseaseMaster GetDiseaseDetailsById(int DiseaseId)
        {
            try
            {
                if (DiseaseId == 0)
                {
                    return new lmsDiseaseMaster();
                }
                var resultDetails = _objLabManagementEntities.lmsDiseaseMasters.FirstOrDefault(x => x.DISEASEID == DiseaseId);
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
        public IList<lmsDiseaseMaster> GetAllDiseases()
        {
            try
            {

                var resultDetails = _objLabManagementEntities.lmsDiseaseMasters.Select(x => x);
                return resultDetails.ToList();
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
        public int SaveDisease(lmsDiseaseMaster objlmsDiseaseMaster)
        {
            var resultId = 0;
            try
            {
                if (objlmsDiseaseMaster.DISEASEID > 0)
                {
                    _objLabManagementEntities.lmsDiseaseMasters.Attach(objlmsDiseaseMaster);
                    _objLabManagementEntities.Entry(objlmsDiseaseMaster).State = EntityState.Modified;
                }
                else
                {
                    _objLabManagementEntities.lmsDiseaseMasters.Add(objlmsDiseaseMaster);
                }
                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsDiseaseMasters.AsEnumerable().LastOrDefault().DISEASEID;
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
        public int DeleteDisease(int DiseaseId)
        {
            var resultFlag = 0;
            try
            {
                var resultObject = _objLabManagementEntities.lmsDiseaseMasters.FirstOrDefault(x => x.DISEASEID == DiseaseId);
                _objLabManagementEntities.lmsDiseaseMasters.Remove(resultObject);
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
        public lmsTemplateMaster GetTemplateDetailsById(int templateId)
        {
            try
            {
                if (templateId == 0)
                {
                    return new lmsTemplateMaster();
                }
                var resultDetails = _objLabManagementEntities.lmsTemplateMasters.FirstOrDefault(x => x.TEMPLATEID == templateId);
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
        public IList<lmsTemplateMaster> GetAllTemplate()
        {
            try
            {

                var resultDetails = _objLabManagementEntities.lmsTemplateMasters.Select(x => x);
                return resultDetails.ToList();
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
        public int SaveTemplate(lmsTemplateMaster objTemplateMaster)
        {
            var resultId = 0;
            try
            {
                if (objTemplateMaster.TEMPLATEID > 0)
                {
                    _objLabManagementEntities.lmsTemplateMasters.Attach(objTemplateMaster);
                    _objLabManagementEntities.Entry(objTemplateMaster).State = EntityState.Modified;
                }
                else
                {
                    _objLabManagementEntities.lmsTemplateMasters.Add(objTemplateMaster);
                }
                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsTemplateMasters.AsEnumerable().LastOrDefault().TEMPLATEID;
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
        public int DeleteTemplate(int templateId)
        {
            var resultFlag = 0;
            try
            {
                var cityObject = _objLabManagementEntities.lmsTemplateMasters.FirstOrDefault(x => x.TEMPLATEID == templateId);
                _objLabManagementEntities.lmsTemplateMasters.Remove(cityObject);
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
        public string GetUserRole(string userName)
        {
            var userRole = "";
            try
            {
                userRole = _objLabManagementEntities.lmsLoginRegistrations.Where(x => x.LOGINEMAILID == userName).FirstOrDefault().lmsRoleMaster.ROLENAME;
            }
            catch (Exception ex)
            {

                _objIAppLogger.LogError(ex);
            }
            return userRole;
        }
        public AdminDashboard GetAdminDashboardInfo(string filterDate = "")
        {
            var objAdminResult = new AdminDashboard();
            if (string.IsNullOrEmpty(filterDate))
                filterDate = DateTime.Now.ToString("MM-dd-yyyy");
            try
            {
                objAdminResult.ExpiryDrugs = _objLabManagementEntities.usp_GetExpiryDrugsByDays(10).ToList();
                objAdminResult.DrugStocks = _objLabManagementEntities.usp_GetDrugStocks().ToList();
                objAdminResult.IpRegistration = _objLabManagementEntities.usp_GetInPatientDetails(filterDate).ToList();
                objAdminResult.OpRegistration = _objLabManagementEntities.usp_GetOutPatients(filterDate).ToList();
                objAdminResult.ProfitLoss = _objLabManagementEntities.usp_GetMedicalProfitLoss(filterDate).ToList();
                objAdminResult.MedicalBillByDate = _objLabManagementEntities.usp_GetMedicalBillsByDate(filterDate).ToList();

                objAdminResult.AvailableDrugsCount = objAdminResult.DrugStocks.Sum(x => x.AvailableStock.HasValue ? x.AvailableStock.Value : 0);
                objAdminResult.TotalTodayIpRegistration = objAdminResult.IpRegistration.Count();
                objAdminResult.TotalTodayOpRegistration = objAdminResult.OpRegistration.Count();
                objAdminResult.NetPharmachyProfitLLoss = objAdminResult.ProfitLoss.Sum(x => x.NETPROFITPERDRUG.HasValue ? x.NETPROFITPERDRUG.Value : 0);
            }
            catch (Exception ex)
            {

                _objIAppLogger.LogError(ex);
            }
            return objAdminResult;
        }
        public void DataArchival(string archType, DateTime fromDate, DateTime toDate)
        {
            try
            {
                _objLabManagementEntities.USP_DATAARCHIVAL(archType, fromDate, toDate);
            }
            catch
            {

            }
        }
    }
}
