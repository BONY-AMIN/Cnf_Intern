using CnF.Domain.Repositories;
using CnF.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnF.Core.Services
{
    public class NotificationService
      
    {
        private UnitOfWork unitOfWork;

        public NotificationService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public List<string> GetNotification()
        {
            var notifications = (from s in unitOfWork.JobRepository.Get()
                                 where s.IsDone == true 
                                 select "Job No: " + s.JobNo + " is  Done."
                                 ).ToList();

            var notifications1 = (from s in unitOfWork.JobRepository.Get()
                                 where s.IsActive == true
                                 select "Job No: " + s.JobNo + " is Active."
                                 ).ToList();

            notifications.AddRange(notifications1);

            return notifications;
        }
    }
}
