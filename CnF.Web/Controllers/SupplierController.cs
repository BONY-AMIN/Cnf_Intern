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
    public class SupplierController : Controller
    {
        private UnitOfWork unitOfWork;
        private SupplierService supplierService;


        public SupplierController()
        {
            unitOfWork = new UnitOfWork();
            supplierService = new SupplierService(unitOfWork);
        }
      
        public ActionResult Index()
        {
            var data = supplierService.GetAll();
            return View(data);
        }

        public ActionResult Create()
        {
        
            return View();
        }

        [HttpPost]
        public ActionResult Create(SupplierViewModel supplierVM)
        {
            supplierService.Create(supplierVM);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var post = supplierService.GetByID(id);

            return View(post);
        }

        [HttpPost]
        public ActionResult Edit(SupplierViewModel supplierVM)
        {
            supplierService.Update(supplierVM);

            return RedirectToAction("Index");
        }
    }
}