using Lab.Management.Common;
using Lab.Management.Engine.Models;
using Lab.Management.Engine.Service;
using Lab.Management.Entities;
using Lab.Management.Logger;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Lab.Management.Engine.Infrastructure
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
                var resultDetails = _objLabManagementEntities.usp_ValidateUser(userName).ToList();
                if (!resultDetails.Any())
                {
                    return null;
                }
                var userData = resultDetails.FirstOrDefault();
                var plainPassword = CryptoManager.passwordDecrypt(userData.LOGINPASSWORD);
                return plainPassword == password ? userData : null;
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
                    _objLabManagementEntities.SaveChanges();
                    return objCityMaster.CITYID;
                }
                _objLabManagementEntities.lmsCityMasters.Add(objCityMaster);
                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsCityMasters.LastOrDefault().CITYID;
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
                    _objLabManagementEntities.SaveChanges();
                    return objStateMaster.STATEID;
                }
                _objLabManagementEntities.lmsStateMasters.Add(objStateMaster);
                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsStateMasters.LastOrDefault().STATEID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
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
                    _objLabManagementEntities.SaveChanges();
                    return objRoleMaster.ROLEID;
                }
                _objLabManagementEntities.lmsRoleMasters.Add(objRoleMaster);
                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsRoleMasters.LastOrDefault().ROLEID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
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

            return resultFlag;
        }

        public lmsHospitalMaster GetHospitalDetailsById(int HospitalId)
        {
            try
            {
                if (HospitalId == 0)
                {
                    var newHospital = new lmsHospitalMaster
                    {
                        ISOCERTIFIED = true
                    };
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
                    _objLabManagementEntities.SaveChanges();
                    return objHospitalMaster.HOSPITALID;
                }
                _objLabManagementEntities.lmsHospitalMasters.Add(objHospitalMaster);
                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsHospitalMasters.LastOrDefault().HOSPITALID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
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

            return resultFlag;
        }

        public lmsLoginRegistration GetUserDetailsById(int UserId)
        {
            try
            {
                if (UserId == 0)
                {
                    var newUser = new lmsLoginRegistration
                    {
                        ISACTIVE = false
                    };
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
        }

        public int SaveUser(lmsLoginRegistration objlmsLoginRegistration)
        {
            var resultId = 0;
            try
            {
                if (!string.IsNullOrEmpty(objlmsLoginRegistration.LOGINPASSWORD))
                {
                    objlmsLoginRegistration.LOGINPASSWORD = CryptoManager.passwordEncrypt(objlmsLoginRegistration.LOGINPASSWORD);
                }

                if (objlmsLoginRegistration.LOGINID > 0)
                {
                    _objLabManagementEntities.lmsLoginRegistrations.Attach(objlmsLoginRegistration);
                    _objLabManagementEntities.Entry(objlmsLoginRegistration).State = EntityState.Modified;
                    _objLabManagementEntities.SaveChanges();
                    return objlmsLoginRegistration.LOGINID;
                }
                _objLabManagementEntities.lmsLoginRegistrations.Add(objlmsLoginRegistration);
                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsLoginRegistrations.LastOrDefault().LOGINID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
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
                    _objLabManagementEntities.SaveChanges();
                    return objlmsDiseaseMaster.DISEASEID;
                }
                _objLabManagementEntities.lmsDiseaseMasters.Add(objlmsDiseaseMaster);
                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsDiseaseMasters.AsEnumerable().LastOrDefault().DISEASEID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
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
                    _objLabManagementEntities.SaveChanges();
                    return objTemplateMaster.TEMPLATEID;
                }
                _objLabManagementEntities.lmsTemplateMasters.Add(objTemplateMaster);
                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsTemplateMasters.AsEnumerable().LastOrDefault().TEMPLATEID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
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
            {
                filterDate = DateTime.Now.ToString("MM-dd-yyyy");
            }

            try
            {
                objAdminResult.ExpiryDrugs = _objLabManagementEntities.usp_GetExpiryDrugsByDays(1).ToList();
                objAdminResult.DrugStocks = _objLabManagementEntities.usp_GetDrugStocks().ToList();
                objAdminResult.IpRegistration = _objLabManagementEntities.usp_GetInPatientDetails(filterDate).ToList();
                objAdminResult.OpRegistration = _objLabManagementEntities.usp_GetOutPatients(filterDate).ToList();
                objAdminResult.ProfitLoss = _objLabManagementEntities.usp_GetMedicalProfitLoss(filterDate).ToList();
                objAdminResult.MedicalBillByDate = _objLabManagementEntities.usp_GetMedicalBillsByDate(filterDate).ToList();
                if(objAdminResult.DrugStocks.Any())
                {
                    objAdminResult.AvailableDrugsCount = objAdminResult.DrugStocks.Sum(x => x.AvailableStock.HasValue ? x.AvailableStock.Value : 0);
                }         
                objAdminResult.TotalTodayIpRegistration = objAdminResult.IpRegistration.Count();
                objAdminResult.TotalTodayOpRegistration = objAdminResult.OpRegistration.Count();
                if (objAdminResult.ProfitLoss.Any())
                {
                    objAdminResult.NetPharmachyProfitLLoss = objAdminResult.ProfitLoss.Sum(x => x.NETPROFITPERDRUG.HasValue ? x.NETPROFITPERDRUG.Value : 0);
                }
              
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
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }
        }

        public lmsDrugDosage GetDrugDosageById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new lmsDrugDosage();
                }
                var resultDetails = _objLabManagementEntities.lmsDrugDosages.FirstOrDefault(x => x.DOSAGEID == id);
                return resultDetails;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public IList<lmsDrugDosage> GetAllDrugDosage()
        {
            try
            {
                var resultDetails = _objLabManagementEntities.lmsDrugDosages.Select(x => x);
                return resultDetails.Any() ? resultDetails.ToList() : new List<lmsDrugDosage>();
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public int SaveDrugDosage(lmsDrugDosage objSaveData)
        {
            var resultId = 0;
            try
            {
                if (objSaveData.DOSAGEID > 0)
                {
                    _objLabManagementEntities.lmsDrugDosages.Attach(objSaveData);
                    _objLabManagementEntities.Entry(objSaveData).State = EntityState.Modified;
                    _objLabManagementEntities.SaveChanges();
                    return objSaveData.DOSAGEID;
                }
                _objLabManagementEntities.lmsDrugDosages.Add(objSaveData);
                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsDrugDosages.ToList().LastOrDefault().DOSAGEID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }

            return resultId;
        }

        public int DeleteDrugDosage(int id)
        {
            var resultFlag = 0;
            try
            {
                var objResult = _objLabManagementEntities.lmsDrugDosages.FirstOrDefault(x => x.DOSAGEID == id);
                _objLabManagementEntities.lmsDrugDosages.Remove(objResult);
                _objLabManagementEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                resultFlag = -1;
                _objIAppLogger.LogError(ex);
            }
            return resultFlag;
        }

        public lmsDrugFrequency GetDrugFrequencyById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new lmsDrugFrequency();
                }
                var resultDetails = _objLabManagementEntities.lmsDrugFrequencies.FirstOrDefault(x => x.FREQUENCYID == id);
                return resultDetails;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public IList<lmsDrugFrequency> GetAllDrugFrequency()
        {
            try
            {
                var resultDetails = _objLabManagementEntities.lmsDrugFrequencies.Select(x => x);
                return resultDetails.Any() ? resultDetails.ToList() : new List<lmsDrugFrequency>();
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
                return null;
            }
        }

        public int SaveDrugFrequency(lmsDrugFrequency objSaveData)
        {
            var resultId = 0;
            try
            {
                if (objSaveData.FREQUENCYID > 0)
                {
                    _objLabManagementEntities.lmsDrugFrequencies.Attach(objSaveData);
                    _objLabManagementEntities.Entry(objSaveData).State = EntityState.Modified;
                    _objLabManagementEntities.SaveChanges();
                    return objSaveData.FREQUENCYID;
                }
                _objLabManagementEntities.lmsDrugFrequencies.Add(objSaveData);
                _objLabManagementEntities.SaveChanges();
                resultId = _objLabManagementEntities.lmsDrugFrequencies.ToList().LastOrDefault().FREQUENCYID;
            }
            catch (Exception ex)
            {
                _objIAppLogger.LogError(ex);
            }

            return resultId;
        }

        public int DeleteDrugFrequency(int id)
        {
            var resultFlag = 0;
            try
            {
                var objResult = _objLabManagementEntities.lmsDrugFrequencies.FirstOrDefault(x => x.FREQUENCYID == id);
                _objLabManagementEntities.lmsDrugFrequencies.Remove(objResult);
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
