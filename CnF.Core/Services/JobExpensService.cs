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
    public class JobExpensService
    {
        private UnitOfWork unitOfWork;

        public JobExpensService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public void Create(JobExpensViewModel jobExpensVM)
        {
            var JobExpens = new JobExpens
            {
                 
                 VoucherNo=jobExpensVM.VoucherNo,
                 Date= jobExpensVM.Date,
                 JobId= jobExpensVM.JobId,
                 AccHeadId= jobExpensVM.AccHeadId,
                 AccountId= jobExpensVM.AccountId,
                 Particulars= jobExpensVM.Particulars,
                 Amount= jobExpensVM.Amount,
                 Job = jobExpensVM.Job
            };

            unitOfWork.JobExpensRepository.Insert(JobExpens);
            unitOfWork.Save();
        }

        public void Update(JobExpensViewModel jobExpensVM)
        {
            var JobExpens = new JobExpens
            {
                Id =jobExpensVM.Id,
                VoucherNo = jobExpensVM.VoucherNo,
                Date = jobExpensVM.Date,
                JobId = jobExpensVM.JobId,
                AccHeadId = jobExpensVM.AccHeadId,
                AccountId = jobExpensVM.AccountId,
                Particulars = jobExpensVM.Particulars,
                Amount = jobExpensVM.Amount,
                Job = jobExpensVM.Job
            };


            unitOfWork.JobExpensRepository.Update(JobExpens);

            unitOfWork.Save();
        }


        public JobExpensViewModel GetByID(int id)
        {
            var data = (from s in unitOfWork.JobExpensRepository.Get()
                        where s.Id == id
                        select new JobExpensViewModel
                        {
                            Id=s.Id,
                            VoucherNo = s.VoucherNo,
                            Date = s.Date,
                            JobId = s.JobId,
                            AccHeadId = s.AccHeadId,
                            AccountId = s.AccountId,
                            Particulars = s.Particulars,
                            Amount = s.Amount,
                            Job = s.Job


                        }).SingleOrDefault();

            return data;
        }

        public IEnumerable<JobExpensViewModel> GetAll()
        {
            var data = (from s in unitOfWork.JobExpensRepository.Get()
                        select new JobExpensViewModel
                        {
                            Id = s.Id,
                            VoucherNo = s.VoucherNo,
                            Date = s.Date,
                            JobId = s.JobId,
                            AccHeadId = s.AccHeadId,
                            AccountId = s.AccountId,
                            Particulars = s.Particulars,
                            Amount = s.Amount,
                            Job = s.Job

                        }).AsEnumerable();

            return data;
        }

    }
}
