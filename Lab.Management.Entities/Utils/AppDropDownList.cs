using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab.Management.Entities
{
    public enum Gender
    {
        [Display(Name = "Male")]
        Male,
        [Display(Name = "FeMale")]
        Female,
        [Display(Name = "TransGender")]
        TransGender
    }
  
}