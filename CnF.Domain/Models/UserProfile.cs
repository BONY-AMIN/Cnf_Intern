//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CnF.Domain.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserProfile
    {
        public string UserId { get; set; }
        public int BranchId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public bool IsActive { get; set; }
        public string ResUserId { get; set; }
        public System.DateTime SystemDate { get; set; }
        public System.DateTime SetDate { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
    }
}