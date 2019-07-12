using System.Collections.Generic;
using System.Web.Mvc;

namespace Lab.Management.Entities
{
    public partial class lmsOutPatientMaster
    {
        public int SelectedDisease { get; set; }
        public IEnumerable<SelectListItem> DiseaseDdl { get; set; }

        public int Sex { get; set; }
    }
}
