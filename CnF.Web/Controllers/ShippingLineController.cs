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
    public class ShippingLineController : Controller
    {
        private UnitOfWork unitOfWork;
        private ShippingLineService shippingLineService;
        private BranchService branchService;


        public ShippingLineController()
        {
            unitOfWork = new UnitOfWork();
            shippingLineService = new ShippingLineService(unitOfWork);
            branchService = new BranchService(unitOfWork);
        }

        public ActionResult Index()
        {
            var data = shippingLineService.GetAll();
            return View(data);
        }

        public ActionResult Create()
        {
            ViewBag.BranchList = new SelectList(branchService.GetDropDown(), "Value", "Text");
            return View();
        }

        [HttpPost]
        public ActionResult Create(ShippingLineViewModel shippingLineVM)
        {
            shippingLineService.Create(shippingLineVM);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var post = shippingLineService.GetByID(id);
            ViewBag.BranchList = new SelectList(branchService.GetDropDown(), "Value", "Text",post.BranchId );

            return View(post);
        }

        [HttpPost]
        public ActionResult Edit(ShippingLineViewModel shippingLineVM)
        {


            //shippingLineVM.Name = User.Identity.Name;

            shippingLineService.Update(shippingLineVM);

            return RedirectToAction("Index");
        }
    }
}