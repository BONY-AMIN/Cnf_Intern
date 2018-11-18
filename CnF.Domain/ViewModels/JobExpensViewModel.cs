using CnF.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnF.Domain.ViewModels
{
    public class JobExpensViewModel
    {
        public int Id { get; set; }
        public string VoucherNo { get; set; }
        public System.DateTime Date { get; set; }
        public int JobId { get; set; }
        public int AccHeadId { get; set; }
        public int AccountId { get; set; }
        public string Particulars { get; set; }
        public decimal Amount { get; set; }

        public virtual Job Job { get; set; }
    }
}
