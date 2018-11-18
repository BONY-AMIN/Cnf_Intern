using CnF.Core.Services;
using CnF.Domain.Repositories;
using CnF.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CnF.Web.Controllers
{
    public class CountryController : Controller
    {
        private UnitOfWork unitOfWork;
        private CountryService countryService;


        public CountryController()
        {
            unitOfWork = new UnitOfWork();
            countryService = new CountryService(unitOfWork);
        }

        public ActionResult Index()
        {
            var data = countryService.GetAll();
            return View(data);
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(CountryViewModel countryVM)
        {
            countryService.Create(countryVM);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var post = countryService.GetByID(id);

            return View(post);
        }

        [HttpPost]
        public ActionResult Edit(CountryViewModel countryVM)
        {


            //countryVM.Name = User.Identity.Name;

            countryService.Update(countryVM);

            return RedirectToAction("Index");
        }
    }
}