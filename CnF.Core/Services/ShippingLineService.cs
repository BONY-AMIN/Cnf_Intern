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
    public class ShippingLineService
    {
        private UnitOfWork unitOfWork;

        public ShippingLineService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public void Create(ShippingLineViewModel shippingLineVM)
        {
            var ShippingLine = new ShippingLine
            {
                 
                 Name= shippingLineVM.Name,
                 AgentType= shippingLineVM.AgentType,
                 BranchId= shippingLineVM.BranchId,
                 Address= shippingLineVM.Address,
                 PhoneNo=shippingLineVM.PhoneNo,
                 MobileNo= shippingLineVM.MobileNo,
                 FAX= shippingLineVM.FAX,
                 Email= shippingLineVM.Email,
                 Web= shippingLineVM.Web,
                 ModifiedBy= shippingLineVM.ModifiedBy,
                 MidifiedDate= shippingLineVM.MidifiedDate,
                 Branch= shippingLineVM.Branch
            };

            unitOfWork.ShippingLineRepository.Insert(ShippingLine);
            unitOfWork.Save();
        }

        public void Update(ShippingLineViewModel shippingLineVM)
        {
            var ShippingLine = new ShippingLine
            {
                Id =shippingLineVM.Id ,
                Name = shippingLineVM.Name,
                AgentType = shippingLineVM.AgentType,
                BranchId = shippingLineVM.BranchId,
                Address = shippingLineVM.Address,
                PhoneNo = shippingLineVM.PhoneNo,
                MobileNo = shippingLineVM.MobileNo,
                FAX = shippingLineVM.FAX,
                Email = shippingLineVM.Email,
                Web = shippingLineVM.Web,
                ModifiedBy = shippingLineVM.ModifiedBy,
                MidifiedDate = shippingLineVM.MidifiedDate,
                Branch = shippingLineVM.Branch
            };


            unitOfWork.ShippingLineRepository.Update(ShippingLine);

            unitOfWork.Save();
        }


        public ShippingLineViewModel GetByID(int id)
        {
            var data = (from s in unitOfWork.ShippingLineRepository.Get()
                        where s.Id == id
                        select new ShippingLineViewModel
                        {
                            Id = s.Id,
                            Name = s.Name,
                            AgentType = s.AgentType,
                            BranchId = s.BranchId,
                            Address = s.Address,
                            PhoneNo = s.PhoneNo,
                            MobileNo = s.MobileNo,
                            FAX = s.FAX,
                            Email = s.Email,
                            Web = s.Web,
                            ModifiedBy = s.ModifiedBy,
                            MidifiedDate = s.MidifiedDate,
                            Branch = s.Branch

                        }).SingleOrDefault();

            return data;
        }

        public IEnumerable<ShippingLineViewModel> GetAll()
        {
            var data = (from s in unitOfWork.ShippingLineRepository.Get()
                        select new ShippingLineViewModel
                        {
                            Id = s.Id,
                            Name = s.Name,
                            AgentType = s.AgentType,
                            BranchId = s.BranchId,
                            Address = s.Address,
                            PhoneNo = s.PhoneNo,
                            MobileNo = s.MobileNo,
                            FAX = s.FAX,
                            Email = s.Email,
                            Web = s.Web,
                            ModifiedBy = s.ModifiedBy,
                            MidifiedDate = s.MidifiedDate,
                            Branch = s.Branch

                        }).AsEnumerable();

            return data;
        }

    }
}
