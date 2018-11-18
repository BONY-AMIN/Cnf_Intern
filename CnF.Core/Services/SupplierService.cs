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
    public class SupplierService
    {
        private UnitOfWork unitOfWork;

        public SupplierService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public void Create(SupplierViewModel supplierVM)
        {
            var Supplier = new Supplier
            {
                Name = supplierVM.Name
            };

            unitOfWork.SupplierRepository.Insert(Supplier);
            unitOfWork.Save();
        }

        public void Update(SupplierViewModel supplierVM)
        {
            var Supplier = new Supplier
            {
                Id = supplierVM.Id,
                Name = supplierVM.Name
            };

            unitOfWork.SupplierRepository.Update(Supplier);

            unitOfWork.Save();
        }


        public SupplierViewModel GetByID(int id)
        {
            var data = (from s in unitOfWork.SupplierRepository.Get()
                        where s.Id == id
                        select new SupplierViewModel
                        {
                            Id = s.Id,
                            Name=s.Name
                        }).SingleOrDefault();

            return data;
        }

        public IEnumerable<SupplierViewModel> GetAll()
        {
            var data = (from s in unitOfWork.SupplierRepository.Get()
                        select new SupplierViewModel
                        {
                            Id = s.Id,
                            Name = s.Name
                        }).AsEnumerable();

            return data;
        }

        public IEnumerable<DropDownViewModel> GetDropDown()
        {
            var data = (from s in unitOfWork.SupplierRepository.Get()
                        select new DropDownViewModel
                        {
                            Value = s.Id,
                            Text = s.Name
                        }).AsEnumerable();

            return data;
        }
    }
}
