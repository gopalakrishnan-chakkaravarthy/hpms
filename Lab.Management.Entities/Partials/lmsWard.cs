using System.Collections.Generic;
using System.Web.Mvc;

namespace Lab.Management.Entities
{
    public partial class lmsWard
    {
        public int SelectedBed { get; set; }
        public IEnumerable<SelectListItem> BedDdl { get; set; }
    }
}
