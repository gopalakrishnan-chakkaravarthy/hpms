namespace Lab.Management.Entities
{

using System;
    using System.Collections.Generic;
    
public partial class lmsTaxMaster
{

    public lmsTaxMaster()
    {

        this.lmsDrugDetails = new HashSet<lmsDrugDetail>();

        this.lmsDrugs = new HashSet<lmsDrug>();

        this.lmsDrugsTaxes = new HashSet<lmsDrugsTax>();

    }


    public int TAXID { get; set; }

    public string TAXNAME { get; set; }

    public string TAXDESCRIPTION { get; set; }

    public Nullable<double> PERCENTAGE { get; set; }

    public Nullable<bool> ISACTIVE { get; set; }

    public Nullable<System.DateTime> CREATEDATE { get; set; }



    public virtual ICollection<lmsDrugDetail> lmsDrugDetails { get; set; }

    public virtual ICollection<lmsDrug> lmsDrugs { get; set; }

    public virtual ICollection<lmsDrugsTax> lmsDrugsTaxes { get; set; }

}

}
