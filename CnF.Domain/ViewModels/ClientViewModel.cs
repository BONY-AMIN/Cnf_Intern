using CnF.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnF.Domain.ViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        public string ClientCode { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string AccountNo { get; set; }
        public int BranchId { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string FAX { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual Branch Branch { get; set; }
    }
}
