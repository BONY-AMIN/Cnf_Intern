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
    public class ClientService
    {
        private UnitOfWork unitOfWork;

        public ClientService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public void Create(ClientViewModel clientVM)
        {
            var Client = new Client
            {

                 
                 ClientCode=clientVM.ClientCode,
                 Name=clientVM.Name,
                 ShortName=clientVM.ShortName,
                 AccountNo=clientVM.AccountNo, 
                 BranchId =clientVM.BranchId,
                 Address=clientVM.Address,
                 PhoneNo=clientVM.PhoneNo,
                 MobileNo=clientVM.MobileNo, 
                 FAX=clientVM.FAX,
                 Email=clientVM.Email,
                 Web=clientVM.Web,
                 ModifiedBy=clientVM.ModifiedBy,
                 ModifiedDate=clientVM.ModifiedDate,
                Branch=clientVM.Branch
    };

            unitOfWork.ClientRepository.Insert(Client);
            unitOfWork.Save();
        }

        public void Update(ClientViewModel clientVM)
        {
            var Client = new Client
            {
                Id =clientVM.Id ,
                ClientCode = clientVM.ClientCode,
                Name = clientVM.Name,
                ShortName = clientVM.ShortName,
                AccountNo = clientVM.AccountNo,
                BranchId = clientVM.BranchId,
                Address = clientVM.Address,
                PhoneNo = clientVM.PhoneNo,
                MobileNo = clientVM.MobileNo,
                FAX = clientVM.FAX,
                Email = clientVM.Email,
                Web = clientVM.Web,
                ModifiedBy = clientVM.ModifiedBy,
                ModifiedDate = clientVM.ModifiedDate,
                Branch = clientVM.Branch
            };

            unitOfWork.ClientRepository.Update(Client);

            unitOfWork.Save();
        }


        public ClientViewModel GetByID(int id)
        {
            var data = (from s in unitOfWork.ClientRepository.Get()
                        where s.Id == id
                        select new ClientViewModel
                        {
                            Id=s.Id,
                            ClientCode = s.ClientCode,
                            Name = s.Name,
                            ShortName = s.ShortName,
                            AccountNo = s.AccountNo,
                            BranchId = s.BranchId,
                            Address = s.Address,
                            PhoneNo = s.PhoneNo,
                            MobileNo = s.MobileNo,
                            FAX = s.FAX,
                            Email = s.Email,
                            Web = s.Web,
                            ModifiedBy = s.ModifiedBy,
                            ModifiedDate = s.ModifiedDate,
                            Branch = s.Branch

                        }).SingleOrDefault();

            return data;
        }

        public IEnumerable<ClientViewModel> GetAll()
        {
            var data = (from s in unitOfWork.ClientRepository.Get()
                        select new ClientViewModel
                        {
                            Id = s.Id,
                            ClientCode = s.ClientCode,
                            Name = s.Name,
                            ShortName = s.ShortName,
                            AccountNo = s.AccountNo,
                            BranchId = s.BranchId,
                            Address = s.Address,
                            PhoneNo = s.PhoneNo,
                            MobileNo = s.MobileNo,
                            FAX = s.FAX,
                            Email = s.Email,
                            Web = s.Web,
                            ModifiedBy = s.ModifiedBy,
                            ModifiedDate = s.ModifiedDate,
                            Branch = s.Branch

                        }).AsEnumerable();

            return data;
        }
        public IEnumerable<DropDownViewModel> GetDropDown()
        {
            var data = (from s in unitOfWork.ClientRepository.Get()
                        select new DropDownViewModel
                        {
                            Value = s.Id,
                            Text = s.Name
                        }).AsEnumerable();

            return data;
        }
    }
}
