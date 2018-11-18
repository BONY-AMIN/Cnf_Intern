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
    public class BillingController : Controller
    {
        private UnitOfWork unitOfWork;
        private BillingService billingService;
        private JobService jobService;



        public BillingController()
        {
            unitOfWork = new UnitOfWork();
            billingService = new BillingService(unitOfWork);
            jobService = new JobService(unitOfWork);
        }

        public ActionResult Index()
        {
            var data = billingService.GetAll();
            return View(data);
        }

        public ActionResult Create()
        {
            ViewBag.JobList = new SelectList(jobService.GetDropDown(), "Value", "Text");
            return View();
        }

        [HttpPost]
        public ActionResult Create(BillingViewModel billingVM)
        {
            billingService.Create(billingVM);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var post = billingService.GetByID(id);
            ViewBag.JobList = new SelectList(jobService.GetDropDown(), "Value", "Text",post.JobId );

            return View(post);
        }

        [HttpPost]
        public ActionResult Edit(BillingViewModel billingVM)
        {
            

            //billingVM.BillNo = User.Identity.Name;

            billingService.Update(billingVM);

            return RedirectToAction ("Index");
        }


    }
}