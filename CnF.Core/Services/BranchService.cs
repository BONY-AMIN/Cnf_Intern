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
    public class BranchService
    {
        private UnitOfWork unitOfWork;

        public BranchService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public void Create(BranchViewModel branchVM)
        {
            var Branch = new Branch
            {
                
                 Name=branchVM.Name,
                 OpenDate=branchVM.OpenDate,
                 IsActive=branchVM.IsActive,
                 IsHeadOffice=branchVM.IsHeadOffice
    };

            unitOfWork.BranchRepository.Insert(Branch);
            unitOfWork.Save();
        }

        public void Update(BranchViewModel branchVM)
        {
            var Branch = new Branch
            {
                BranchId = branchVM .BranchId,
                Name = branchVM.Name,
                OpenDate = branchVM.OpenDate,
                IsActive = branchVM.IsActive,
                IsHeadOffice = branchVM.IsHeadOffice

            };


            unitOfWork.BranchRepository.Update(Branch);

            unitOfWork.Save();
        }


        public BranchViewModel GetByID(int id)
        {
            var data = (from s in unitOfWork.BranchRepository.Get()
                        where s.BranchId == id
                        select new BranchViewModel
                        {
                            BranchId = s.BranchId,
                            Name = s.Name,
                            OpenDate = s.OpenDate,
                            IsActive = s.IsActive,
                            IsHeadOffice = s.IsHeadOffice


                        }).SingleOrDefault();

            return data;
        }

        public IEnumerable<BranchViewModel> GetAll()
        {
            var data = (from s in unitOfWork.BranchRepository.Get()
                        select new BranchViewModel
                        {
                            BranchId = s.BranchId,
                            Name = s.Name,
                            OpenDate = s.OpenDate,
                            IsActive = s.IsActive,
                            IsHeadOffice = s.IsHeadOffice

                        }).AsEnumerable();

            return data;
        }
        public IEnumerable<DropDownViewModel> GetDropDown()
        {
            var data = (from s in unitOfWork.BranchRepository.Get()
                        select new DropDownViewModel
                        {
                            Value = s.BranchId ,
                            Text = s.Name
                        }).AsEnumerable();

            return data;
        }

    }
}
