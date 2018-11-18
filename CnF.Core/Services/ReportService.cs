using CnF.Domain.Repositories;
using CnF.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnF.Core.Services
{
    public class ReportService
    {
        private UnitOfWork unitOfWork;

        public ReportService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public IEnumerable<ClientStatusViewModel> GetClientStatus()
        {
            var data = (from s in unitOfWork.ClientRepository.Get()
                        join j in unitOfWork.JobRepository.Get() on s.Id equals j.ImporterId
                        select new ClientStatusViewModel
                        {
                            JobNo = j.JobNo,
                            Name = s.Name,
                            TotalValue = j.Value
                        }).AsEnumerable();

            return data;
        }

        public IEnumerable<BillingStatusViewModel> GetBillingStatus()
        {
            var data = (from j in unitOfWork.JobRepository.Get()
                        join b in unitOfWork.BillingRepository.Get() on j.Id equals b.JobId 
                        select new BillingStatusViewModel 
                        {
                          
                            Id=b.Id ,
                           JobNo=j.JobNo,
                           BillNo=b.BillNo,
                           Amount=b.Amount,
                           
                         
                        }).AsEnumerable();

            return data;
        }

      

       

        public BillingStatusViewModel Details(int id)
        {
            var data = (from j in unitOfWork.JobRepository.Get()
                        join b in unitOfWork.BillingRepository.Get() on j.Id equals b.JobId
                        where b.Id==id
                        select new BillingStatusViewModel
                        {

                            Id = b.Id,
                            JobNo = j.JobNo,
                            BillNo = b.BillNo,
                            Amount = b.Amount,


                        }).SingleOrDefault();

            return data;
        }



        public IEnumerable<RevenueViewModel> GetRevenue()
        {
            var data = (from j in unitOfWork.JobRepository.Get()
                        join b in unitOfWork.BillingRepository.Get() on j.Id equals b.JobId
                        select new RevenueViewModel
                        {

                            JobNo = j.JobNo,
                            BillNo = b.BillNo,

                            Amount = b.Amount,

                        }).AsEnumerable();

            return data ;
        }





    }
}
