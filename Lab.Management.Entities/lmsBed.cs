
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
    
public partial class lmsBed
{

    public lmsBed()
    {

        this.lmsWards = new HashSet<lmsWard>();

    }


    public int BEDID { get; set; }

    public string BEDNAME { get; set; }

    public Nullable<bool> ISACTIVE { get; set; }

    public double ChargePerDay { get; set; }



    public virtual ICollection<lmsWard> lmsWards { get; set; }

}

}
