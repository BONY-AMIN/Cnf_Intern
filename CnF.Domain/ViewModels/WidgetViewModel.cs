using CnF.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CnF.Domain.ViewModels
{
    public class WidgetViewModel
    {
        
        public decimal Value { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDone { get; set; }
        public decimal Amount { get; set; }
    }
}
