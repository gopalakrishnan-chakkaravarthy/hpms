﻿using System.Collections.Generic;
using System.Web.Mvc;

namespace Lab.Management.Entities
{
    public partial class lmsPatientBooking
    {
        public IEnumerable<SelectListItem> PatientDdl { get; set; }

        public IEnumerable<SelectListItem> DiseaseDdl { get; set; }

        public IEnumerable<SelectListItem> BookingStatusDdl { get; set; }
    }
}