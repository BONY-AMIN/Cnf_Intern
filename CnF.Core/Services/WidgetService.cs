using CnF.Domain.Models;

using CnF.Domain.Repositories;
using CnF.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnF.Core.Services
{
    public class WidgetService
    {
        private UnitOfWork unitOfWork;

        public WidgetService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public WidgetViewModel GetWidgetAmount()
        {
            var widget = new WidgetViewModel();

            widget.Amount = (from s in unitOfWork.BillingRepository.Get()
                             select s.Amount).Sum();


            return widget;
        }


        public WidgetViewModel GetWidgetValue()
        {
            var value = new WidgetViewModel();

            value.Value = (from s in unitOfWork.JobRepository.Get()
                           select s.Value).Sum();


            return value;
        }

        public List<string> ActiveJob()
        {
            var active = (from s in unitOfWork.JobRepository.Get()
                          where s.IsActive == true 
                          select "Job No: " + s.JobNo + " is  Active."
                                 ).ToList();

            return active;

        }
        public List<string> CompleteJob()
        {
            var done = (from s in unitOfWork.JobRepository.Get()
                          where s.IsDone == true
                          select "Job No: " + s.JobNo + " is no Done."
                                 ).ToList();

            return done;

        }

        public List<string> UpcomingJob()
        {
            var coming = (from s in unitOfWork.JobRepository.Get()
                        where s.IsDone == false  && s.IsActive==false 
                        select "Job No: " + s.JobNo + " is no Done."
                                 ).ToList();

            return coming;

        }
    }
}