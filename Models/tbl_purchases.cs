//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCFlowerApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_purchases
    {
        public int ID_ticket { get; set; }
        public string Code_product { get; set; }
        public int quantity { get; set; }
        public int PurchaseID { get; set; }
    
        public virtual tbl_ticket tbl_ticket { get; set; }
    }
}
