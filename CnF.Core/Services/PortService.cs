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
    public class PortService
    {
        private UnitOfWork unitOfWork;

        public PortService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public void Create(PortViewModel portVM)
        {
            var Port = new Port
            {
                
                Name=portVM.Name,
                CountryId=portVM.CountryId,
                Country=portVM.Country
                
            };

            unitOfWork.PortRepository.Insert(Port);
            unitOfWork.Save();
        }

        public void Update(PortViewModel portVM)
        {
            var Port = new Port
            {
                Id =portVM.Id,
                Name = portVM.Name,
                CountryId = portVM.CountryId,
                Country = portVM.Country
            };


            unitOfWork.PortRepository.Update(Port);

            unitOfWork.Save();
        }


        public PortViewModel GetByID(int id)
        {
            var data = (from s in unitOfWork.PortRepository.Get()
                        where s.Id == id
                        select new PortViewModel
                        {
                            Id = s.Id,
                            Name = s.Name,
                            CountryId = s.CountryId,
                            Country = s.Country


                        }).SingleOrDefault();

            return data;
        }

        public IEnumerable<PortViewModel> GetAll()
        {
            var data = (from s in unitOfWork.PortRepository.Get()
                        select new PortViewModel
                        {
                            Id = s.Id,
                            Name = s.Name,
                            CountryId = s.CountryId,
                            Country = s.Country


                        }).AsEnumerable();

            return data;
        }
        public IEnumerable<DropDownViewModel> GetDropDown()
        {
            var data = (from s in unitOfWork.PortRepository.Get()
                        select new DropDownViewModel
                        {
                            Value = s.Id,
                            Text = s.Name
                        }).AsEnumerable();

            return data;
        }

    }
}
