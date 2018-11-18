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
    public class CountryService
    {
        private UnitOfWork unitOfWork;

        public CountryService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public void Create(CountryViewModel countryVM)
        {
            var Country = new Country
            {
                Name = countryVM.Name
            };

            unitOfWork.CountryRepository.Insert(Country);
            unitOfWork.Save();
        }

        public void Update(CountryViewModel CountryVM)
        {
            var Country = new Country
            {
                Id=CountryVM.Id ,
                Name = CountryVM.Name
            };

            unitOfWork.CountryRepository.Update(Country);

            unitOfWork.Save();
        }


        public CountryViewModel GetByID(int id)
        {
            var data = (from s in unitOfWork.CountryRepository.Get()
                        where s.Id == id
                        select new CountryViewModel
                        {
                            Id = s.Id,
                            Name = s.Name
                        }).SingleOrDefault();

            return data;
        }

        public IEnumerable<CountryViewModel> GetAll()
        {
            var data = (from s in unitOfWork.CountryRepository.Get()
                        select new CountryViewModel
                        {
                            Id = s.Id,
                            Name = s.Name
                        }).AsEnumerable();

            return data;
        }
        public IEnumerable<DropDownViewModel> GetDropDown()
        {
            var data = (from s in unitOfWork.CountryRepository.Get()
                        select new DropDownViewModel
                        {
                            Value = s.Id,
                            Text = s.Name
                        }).AsEnumerable();

            return data;
        }

    }
}
