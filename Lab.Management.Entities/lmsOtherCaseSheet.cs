
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
    
public partial class lmsOtherCaseSheet
{

    public lmsOtherCaseSheet()
    {

        this.lmsNotes = new HashSet<lmsNote>();

    }


    public int OCSID { get; set; }

    public string NAME { get; set; }

    public Nullable<int> AGE { get; set; }

    public string ADDRESS { get; set; }

    public Nullable<System.DateTime> DOA { get; set; }

    public Nullable<System.DateTime> DOD { get; set; }

    public string PHNO { get; set; }

    public string COMPLAINTS { get; set; }

    public string EXAMINATION { get; set; }

    public string TREATMENT { get; set; }

    public Nullable<System.DateTime> CREDATEDDATE { get; set; }



    public virtual ICollection<lmsNote> lmsNotes { get; set; }

}

}
