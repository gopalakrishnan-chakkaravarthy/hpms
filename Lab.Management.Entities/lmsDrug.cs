
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
    
public partial class lmsDrug
{

    public lmsDrug()
    {

        this.lmsMedicalBillings = new HashSet<lmsMedicalBilling>();

        this.lmsMedicalBillingDetails = new HashSet<lmsMedicalBillingDetail>();

        this.lmsPatientPrescriptions = new HashSet<lmsPatientPrescription>();

        this.lmsDrugDetails = new HashSet<lmsDrugDetail>();

    }


    public int DRUGID { get; set; }

    public string DRUGNAME { get; set; }

    public Nullable<System.DateTime> ORDERDATE { get; set; }

    public Nullable<System.DateTime> MANUFACTUREDATE { get; set; }

    public Nullable<System.DateTime> EXPIRYDATE { get; set; }

    public Nullable<bool> ISEXPIRED { get; set; }

    public Nullable<double> BUYINGPRICE { get; set; }

    public Nullable<double> SELLINGPRICE { get; set; }

    public Nullable<System.DateTime> CREATEDATE { get; set; }

    public Nullable<int> ORDERCOUNT { get; set; }

    public Nullable<int> AVAILABLEORDER { get; set; }

    public string RackNumber { get; set; }

    public string QrCodeContent { get; set; }

    public string QrCodeBase64 { get; set; }



    public virtual ICollection<lmsMedicalBilling> lmsMedicalBillings { get; set; }

    public virtual ICollection<lmsMedicalBillingDetail> lmsMedicalBillingDetails { get; set; }

    public virtual ICollection<lmsPatientPrescription> lmsPatientPrescriptions { get; set; }

    public virtual ICollection<lmsDrugDetail> lmsDrugDetails { get; set; }

}

}
