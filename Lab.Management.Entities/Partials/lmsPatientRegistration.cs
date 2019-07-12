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
}
