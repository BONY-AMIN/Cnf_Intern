using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnF.Domain.ViewModels
{
    public class BillingViewModel
    {
        public int Id { get; set; }
        public string BillNo { get; set; }
        public System.DateTime Date { get; set; }
        public int JobId { get; set; }
        public int AccountId { get; set; }
        public int TypeId { get; set; }
        public decimal Amount { get; set; }
    }
}
