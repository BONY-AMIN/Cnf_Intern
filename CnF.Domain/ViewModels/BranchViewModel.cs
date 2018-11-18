using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnF.Domain.ViewModels
{
    public class BranchViewModel
    {
        public int BranchId { get; set; }
        public string Name { get; set; }
        public System.DateTime OpenDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsHeadOffice { get; set; }

    }
}
