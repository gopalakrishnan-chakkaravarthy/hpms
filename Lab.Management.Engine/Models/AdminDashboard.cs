using Lab.Management.Entities;
using System.Collections.Generic;
namespace Lab.Management.Engine.Models
{
    public class AdminDashboard
    {
        public int AvailableDrugsCount { get; set; }
        public double NetPharmachyProfitLLoss { get; set; }
        public int TotalTodayIpRegistration { get; set; }
        public int TotalTodayOpRegistration { get; set; }
        public IList<usp_GetDrugStocks_Result> DrugStocks { get; set; }
        public IList<usp_GetExpiryDrugsByDays_Result> ExpiryDrugs { get; set; }
        public IList<usp_GetMedicalProfitLoss_Result> ProfitLoss { get; set; }
        public IList<usp_GetInPatientDetails_Result> IpRegistration { get; set; }
        public IList<usp_GetOutPatients_Result> OpRegistration { get; set; }

        public IList<usp_GetMedicalBillsByDate_Result> MedicalBillByDate { get; set; }
        public AdminDashboard()
        {
            DrugStocks = new List<usp_GetDrugStocks_Result>();
            ExpiryDrugs = new List<usp_GetExpiryDrugsByDays_Result>();
            ProfitLoss = new List<usp_GetMedicalProfitLoss_Result>();
            IpRegistration = new List<usp_GetInPatientDetails_Result>();
            OpRegistration = new List<usp_GetOutPatients_Result>();
            MedicalBillByDate = new List<usp_GetMedicalBillsByDate_Result>();
        }

    }
}
