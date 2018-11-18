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
    public class JobController : Controller
    {
        private UnitOfWork unitOfWork;
        private JobService jobService;
        private SupplierService supplierService;
        private PortService portService;
        private CountryService countryService;
        private ClientService clientService;

        public JobController()
        {
            unitOfWork = new UnitOfWork();
            jobService = new JobService(unitOfWork);
            supplierService = new SupplierService(unitOfWork);
            portService = new PortService(unitOfWork);
            countryService = new CountryService(unitOfWork);
            clientService = new ClientService(unitOfWork);
        }

        public ActionResult Index()
        {
            var data = jobService.GetAll();
            return View(data);
        }

        public ActionResult Create()
        {
            ViewBag.SupplierList = new SelectList(supplierService.GetDropDown(), "Value", "Text");
            ViewBag.PortList = new SelectList(portService.GetDropDown(), "Value", "Text");
            ViewBag.CountryList = new SelectList(countryService.GetDropDown(), "Value", "Text");
            ViewBag.ClientList = new SelectList(clientService.GetDropDown(), "Value", "Text");

            return View();
        }

        [HttpPost]
        public ActionResult Create(JobViewModel jobVM)
        {
            jobService.Create(jobVM);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var post = jobService.GetByID(id);
            ViewBag.SupplierList = new SelectList(supplierService.GetDropDown(), "Value", "Text",post.SupplierId );
            ViewBag.PortList = new SelectList(portService.GetDropDown(), "Value", "Text",post.PortId );
            ViewBag.CountryList = new SelectList(countryService.GetDropDown(), "Value", "Text",post.CountryId  );
            ViewBag.ClientList = new SelectList(clientService.GetDropDown(), "Value", "Text",post.ImporterId );

            return View(post);
        }

        [HttpPost]
        public ActionResult Edit(JobViewModel jobVM)
        {
            //jobVM.Name = User.Identity.Name;


            jobService.Update(jobVM);

            return RedirectToAction("Index");
        }

    }
}