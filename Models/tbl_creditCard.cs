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
    
    public partial class tbl_creditCard
    {
        public int id_creditcard { get; set; }
        public string name { get; set; }
        public string digits { get; set; }
        public string month { get; set; }
        public string year { get; set; }
        public string card_address { get; set; }
        public int ID_user { get; set; }
    
        public virtual tbl_users tbl_users { get; set; }
    }
}
