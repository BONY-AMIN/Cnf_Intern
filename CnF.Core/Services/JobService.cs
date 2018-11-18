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
    public class JobService
    {
        private UnitOfWork unitOfWork;

        public JobService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public void Create(JobViewModel jobVM)
        {
            var Job = new Job
            {
                
                JobType=jobVM.JobType,
                JobNo=jobVM.JobNo ,
                JobDate=jobVM.JobDate,
                Value=jobVM.Value,
                ValueUnit=jobVM.ValueUnit,
                ImporterId=jobVM.ImporterId,
                PortId=jobVM.PortId,
                SupplierId=jobVM.SupplierId,
                CountryId=jobVM.CountryId,
                InvoiceNo=jobVM.InvoiceNo,
                InvoiceDate=jobVM.InvoiceDate,
                LCNo=jobVM.LCNo,
                LCDate=jobVM.LCDate,
                IsActive=jobVM.IsActive ,
                IsDone=jobVM.IsDone 

            };

            unitOfWork.JobRepository.Insert(Job);
            unitOfWork.Save();
        }

        public void Update(JobViewModel jobVM)
        {
            var Job= new Job
            {
                Id =jobVM.Id ,
                JobType = jobVM.JobType,
                JobNo = jobVM.JobNo,
                JobDate = jobVM.JobDate,
                Value = jobVM.Value,
                ValueUnit = jobVM.ValueUnit,
                ImporterId = jobVM.ImporterId,
                PortId = jobVM.PortId,
              
                SupplierId = jobVM.SupplierId,
                CountryId = jobVM.CountryId,
                InvoiceNo = jobVM.InvoiceNo,
                InvoiceDate = jobVM.InvoiceDate,
                LCNo = jobVM.LCNo,
                LCDate = jobVM.LCDate,
                IsActive=jobVM.IsActive,
                IsDone=jobVM.IsDone 
            };

            unitOfWork.JobRepository.Update(Job);

            unitOfWork.Save();
        }


        public JobViewModel GetByID(int id)
        {
            var data = (from s in unitOfWork.JobRepository.Get()
                        where s.Id == id
                        select new JobViewModel
                        {
                            Id = s.Id,
                            JobType = s.JobType,
                            JobNo = s.JobNo,
                            JobDate = s.JobDate,
                            Value = s.Value,
                            ValueUnit = s.ValueUnit,
                            ImporterId = s.ImporterId,
                            PortId = s.PortId,
                            SupplierId = s.SupplierId,
                            CountryId = s.CountryId,
                            InvoiceNo = s.InvoiceNo,
                            InvoiceDate = s.InvoiceDate,
                            LCNo = s.LCNo,
                            LCDate = s.LCDate,
                            IsActive =s.IsActive,
                            IsDone =s.IsDone 
                            
                            

                        }).SingleOrDefault();

            return data;
        }

        public IEnumerable<JobViewModel> GetAll()
        {
            var data = (from s in unitOfWork.JobRepository.Get()
                        select new JobViewModel
                        {
                            Id = s.Id,
                            JobType = s.JobType,
                            JobNo = s.JobNo,
                            JobDate = s.JobDate,
                            Value = s.Value,
                            ValueUnit = s.ValueUnit,
                            ImporterId = s.ImporterId,
                           
                            PortId = s.PortId,
                            SupplierId = s.SupplierId,
                            CountryId = s.CountryId,
                            InvoiceNo = s.InvoiceNo,
                            InvoiceDate = s.InvoiceDate,
                            LCNo = s.LCNo,
                            LCDate = s.LCDate,
                            IsActive =s.IsActive,
                            IsDone=s.IsDone

                        }).AsEnumerable();

            return data;
        }
        public IEnumerable<DropDownViewModel> GetDropDown()
        {
            var data = (from s in unitOfWork.JobRepository.Get()
                        select new DropDownViewModel
                        {
                            Value = s.Id,
                            Text = s.JobNo 
                        }).AsEnumerable();

            return data;
        }
    }
}
