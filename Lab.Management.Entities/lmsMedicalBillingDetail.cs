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
    
    public partial class lmsMedicalBillingDetail
    {
        public int BILLDETAILID { get; set; }
        public Nullable<int> BILLID { get; set; }
        public Nullable<int> DRUGID { get; set; }
        public Nullable<int> QUANTITY { get; set; }
        public Nullable<double> ITEMCOST { get; set; }
        public Nullable<System.DateTime> CREATEDATE { get; set; }
    
        public virtual lmsDrug lmsDrug { get; set; }
        public virtual lmsMedicalBilling lmsMedicalBilling { get; set; }
    }
}
