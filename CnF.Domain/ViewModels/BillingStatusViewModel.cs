﻿using CnF.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnF.Domain.ViewModels
{
    public class BillingStatusViewModel
    {
        public int Id { get; set; }
        public string JobNo { get; set; }
        public string BillNo { get; set; }
        public decimal Amount { get; set; }
    }
}
