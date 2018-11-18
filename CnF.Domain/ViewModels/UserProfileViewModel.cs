using CnF.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnF.Domain.ViewModels
{
    public class UserProfileViewModel
    {
        public string UserId { get; set; }
        public int BranchId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string  MobileNo { get; set; }
        public bool IsActive { get; set; }
        public string ResUserId { get; set; }
        public System.DateTime SystemDate { get; set; }
        public System.DateTime SetDate { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Branch Branch { get; set; }
    }
}
