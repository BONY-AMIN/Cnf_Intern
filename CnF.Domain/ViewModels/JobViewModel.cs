using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnF.Domain.ViewModels
{
    public class JobViewModel
    {
        public int Id { get; set; }
        public int JobType { get; set; }
        public string JobNo { get; set; }
        public System.DateTime JobDate { get; set; }
        public decimal Value { get; set; }
        public int ValueUnit { get; set; }
        public Nullable<int> ImporterId { get; set; }
        public Nullable<int> PortId { get; set; }
        public Nullable<int> SupplierId { get; set; }
        public Nullable<int> CountryId { get; set; }
        public string InvoiceNo { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public string LCNo { get; set; }
        public Nullable<System.DateTime> LCDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDone { get; set; }
    }
}
