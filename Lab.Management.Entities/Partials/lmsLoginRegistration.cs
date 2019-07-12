using System.Collections.Generic;
using System.Web.Mvc;

namespace Lab.Management.Entities
{
    public partial class lmsLoginRegistration
    {
        public int SelectedCity { get; set; }
        public IEnumerable<SelectListItem> CityDdl { get; set; }
        public int SelectedState { get; set; }
        public IEnumerable<SelectListItem> StateDdl { get; set; }
        public int SelectedRole { get; set; }
        public IEnumerable<SelectListItem> RoleDdl { get; set; }
    }
}
