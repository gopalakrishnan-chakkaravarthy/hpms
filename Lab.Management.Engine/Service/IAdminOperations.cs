using Lab.Management.Engine.Models;
using Lab.Management.Entities;
using System;
using System.Collections.Generic;

namespace Lab.Management.Engine.Service
{
    public interface IAdminOperations
    {
        usp_ValidateUser_Result ValidateUser(string userName, string password);

        lmsCityMaster GetCityDetailsById(int cityId);

        IList<lmsCityMaster> GetAllCity();

        int SaveCity(lmsCityMaster objCityMaster);

        int DeleteCity(int cityId);

        lmsStateMaster GetStateDetailsById(int StateId);

        IList<lmsStateMaster> GetAllState();

        int SaveState(lmsStateMaster objStateMaster);

        int DeleteState(int StateId);

        lmsRoleMaster GetRoleDetailsById(int RoleId);

        IList<lmsRoleMaster> GetAllRole();

        int SaveRole(lmsRoleMaster objRoleMaster);

        int DeleteRole(int RoleId);

        lmsHospitalMaster GetHospitalDetailsById(int HospitalId);

        IList<lmsHospitalMaster> GetAllHospital();

        int SaveHospital(lmsHospitalMaster objHospitalMaster);

        int DeleteHospital(int HospitalId);

        lmsLoginRegistration GetUserDetailsById(int UserId);

        IList<lmsLoginRegistration> GetAllUsers();

        int SaveUser(lmsLoginRegistration objlmsLoginRegistration);

        int DeleteUser(int UserId);

        lmsDiseaseMaster GetDiseaseDetailsById(int DiseaseId);

        IList<lmsDiseaseMaster> GetAllDiseases();

        int SaveDisease(lmsDiseaseMaster objlmsDiseaseMaster);

        int DeleteDisease(int DiseaseId);

        lmsTemplateMaster GetTemplateDetailsById(int templateId);

        IList<lmsTemplateMaster> GetAllTemplate();

        int SaveTemplate(lmsTemplateMaster objTemplateMaster);

        int DeleteTemplate(int templateId);

        string GetUserRole(string userName);

        AdminDashboard GetAdminDashboardInfo(string filterDate = "");

        void DataArchival(string archType, DateTime fromDate, DateTime toDate);
    }
}
