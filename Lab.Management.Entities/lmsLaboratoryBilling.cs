//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lab.Management.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class lmsLaboratoryBilling
    {
        public lmsLaboratoryBilling()
        {
            this.lmsLaboratoryBillingDetails = new HashSet<lmsLaboratoryBillingDetail>();
        }
    
        public int BILLID { get; set; }
        public string BILLNAME { get; set; }
        public string CONTACT { get; set; }
        public Nullable<int> TESTID { get; set; }
        public Nullable<double> TESTRESULT { get; set; }
        public string UNITS { get; set; }
        public Nullable<double> BILLAMOUNT { get; set; }
        public string BILLBY { get; set; }
        public Nullable<System.DateTime> BILLDATE { get; set; }
        public Nullable<System.DateTime> CREATEDDATE { get; set; }
    
        public virtual ICollection<lmsLaboratoryBillingDetail> lmsLaboratoryBillingDetails { get; set; }
        public virtual lmsMedicalTest lmsMedicalTest { get; set; }
    }
}
