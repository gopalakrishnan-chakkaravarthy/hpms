using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Lab.Management.Entities
{
    public partial class lmsPatientRegistration
    {
        public int SelectedDisease { get; set; }
        public IEnumerable<SelectListItem> DiseaseDdl { get; set; }

        [Required]
        public int Sex { get; set; }
    }

    public partial class lmsOutPatientMaster
    {
        public int SelectedDisease { get; set; }
        public IEnumerable<SelectListItem> DiseaseDdl { get; set; }

        public int Sex { get; set; }
    }

    public partial class lmsDischargeBill
    {
        public int SelectedPatient { get; set; }
        public IEnumerable<SelectListItem> PatientDdl { get; set; }
    }

    public partial class lmsDischargeSummary
    {
        public int SelectedPatient { get; set; }
        public IEnumerable<SelectListItem> PatientDdl { get; set; }
    }

    public partial class lmsInPatientBilling
    {
        public int SelectedPatient { get; set; }
        public IEnumerable<SelectListItem> PatientDdl { get; set; }
    }

    public partial class lmsMedicalBilling
    {
        public int SelectedPatient { get; set; }
        public IEnumerable<SelectListItem> PatientDdl { get; set; }
    }

    public partial class lmsLaboratoryBilling
    {
        public int SelectedPatient { get; set; }
        public IEnumerable<SelectListItem> PatientDdl { get; set; }
    }

    public partial class lmsPatientTemplate
    {
        public int SelectedPatient { get; set; }
        public IEnumerable<SelectListItem> PatientDdl { get; set; }
    }

    public partial class lmsPatientDischargeSummary
    {
        public int SelectedPatient { get; set; }
        public IEnumerable<SelectListItem> PatientDdl { get; set; }
    }

    public partial class lmsInventory
    {
        public int SelectedVendor { get; set; }
        public IEnumerable<SelectListItem> VendorDdl { get; set; }
    }

    public partial class lmsWard
    {
        public int SelectedBed { get; set; }
        public IEnumerable<SelectListItem> BedDdl { get; set; }
    }

    public partial class lmsLoginRegistration
    {
        public int SelectedCity { get; set; }
        public IEnumerable<SelectListItem> CityDdl { get; set; }
        public int SelectedState { get; set; }
        public IEnumerable<SelectListItem> StateDdl { get; set; }
        public int SelectedRole { get; set; }
        public IEnumerable<SelectListItem> RoleDdl { get; set; }
    }

    public partial class lmsGeneralDischargeSummary
    {
        public int SelectedPatient { get; set; }
        public IEnumerable<SelectListItem> PatientDdl { get; set; }
    }

    public partial class lmsGynacDischargeSummary
    {
        public int SelectedPatient { get; set; }
        public IEnumerable<SelectListItem> PatientDdl { get; set; }
    }

    public partial class lmsMedicalTest
    {
        public int SelectedGroup { get; set; }
        public IEnumerable<SelectListItem> GroupForDdl { get; set; }
        public int SelectedTestFor { get; set; }
        public IEnumerable<SelectListItem> TestForForDdl { get; set; }
    }
}
