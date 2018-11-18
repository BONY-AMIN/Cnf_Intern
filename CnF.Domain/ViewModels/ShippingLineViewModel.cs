using CnF.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnF.Domain.ViewModels
{
    public class ShippingLineViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> AgentType { get; set; }
        public int BranchId { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string FAX { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime MidifiedDate { get; set; }

        public virtual Branch Branch { get; set; }
    }
}
