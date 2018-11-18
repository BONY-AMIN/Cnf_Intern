using CnF.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnF.Domain.ViewModels
{
    public class ClientStatusViewModel
    {
        public string Name { get; set; }
        public string JobNo { get; set; }
        public decimal TotalValue { get; set; }
    }
}
