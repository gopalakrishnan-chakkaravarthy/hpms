
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
    
public partial class lmsInventory
{

    public lmsInventory()
    {

        this.lmsVendorBillings = new HashSet<lmsVendorBilling>();

    }


    public int INVENTORYID { get; set; }

    public string ITEMNAME { get; set; }

    public Nullable<bool> ISWORKING { get; set; }

    public Nullable<double> BUYINGPRICE { get; set; }

    public Nullable<System.DateTime> MANUFACTURIGDATE { get; set; }

    public Nullable<int> WARRENTYPERIOD { get; set; }

    public Nullable<int> GUARRETYPERIOD { get; set; }

    public Nullable<int> VENDORID { get; set; }

    public Nullable<System.DateTime> CREATEDDATE { get; set; }



    public virtual lmsVendor lmsVendor { get; set; }

    public virtual ICollection<lmsVendorBilling> lmsVendorBillings { get; set; }

}

}
