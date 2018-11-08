
namespace PMS.Web.Apps.Models
{
    public class QueryStringModel
    {
        public string SessionLoginEmail { get; set; }

        public int SessionLoginId { get; set; }
        public string HospitalId { get; set; }

        public string PatientId { get; set; }
        public string PharmacyId { get; set; }
        public string DiagnosticCenterId { get; set; }
        public bool IsNumeric { get; set; }
    }
}