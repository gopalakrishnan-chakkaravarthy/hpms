
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
    
public partial class lmsTaxMaster
{

    public lmsTaxMaster()
    {

        this.lmsDrugDetails = new HashSet<lmsDrugDetail>();

        this.lmsDrugsTaxes = new HashSet<lmsDrugsTax>();

        this.lmsLabTaxes = new HashSet<lmsLabTax>();

    }


    public int TAXID { get; set; }

    public string TAXNAME { get; set; }

    public string TAXDESCRIPTION { get; set; }

    public Nullable<double> PERCENTAGE { get; set; }

    public Nullable<bool> ISACTIVE { get; set; }

    public Nullable<System.DateTime> CREATEDATE { get; set; }



    public virtual ICollection<lmsDrugDetail> lmsDrugDetails { get; set; }

    public virtual ICollection<lmsDrugsTax> lmsDrugsTaxes { get; set; }

    public virtual ICollection<lmsLabTax> lmsLabTaxes { get; set; }

}

}
