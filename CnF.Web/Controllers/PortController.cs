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
    public class PortController : Controller
    {
        private UnitOfWork unitOfWork;
        private PortService portService;
        private CountryService countryService;


        public PortController()
        {
            unitOfWork = new UnitOfWork();
            portService = new PortService(unitOfWork);
            countryService = new CountryService(unitOfWork);
        }

        public ActionResult Index()
        {
            var data = portService.GetAll();
            return View(data);
        }

        public ActionResult Create()
        {
            ViewBag.CountryList = new SelectList(countryService.GetDropDown(), "Value", "Text");
            return View();
        }

        [HttpPost]
        public ActionResult Create(PortViewModel portVM)
        {
            portService.Create(portVM);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var post = portService.GetByID(id);

            ViewBag.CountryList = new SelectList(countryService.GetDropDown(), "Value", "Text", post.CountryId);

            return View(post);
        }

        [HttpPost]
        public ActionResult Edit(PortViewModel portVM)
        {


            //portVM.Name = User.Identity.Name;

            portService.Update(portVM);

            return RedirectToAction("Index");
        }
    }
}