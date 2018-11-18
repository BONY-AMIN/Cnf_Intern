using CnF.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnF.Domain.ViewModels
{
    public class PortViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
