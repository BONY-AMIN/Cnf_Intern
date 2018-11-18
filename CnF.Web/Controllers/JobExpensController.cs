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
    public class JobExpensController : Controller
    {
        private UnitOfWork unitOfWork;
        private JobExpensService jobExpensService;
        private JobService jobService;


        public JobExpensController()
        {
            unitOfWork = new UnitOfWork();
            jobExpensService = new JobExpensService(unitOfWork);
            jobService = new JobService(unitOfWork);
        }

        public ActionResult Index()
        {
            var data = jobExpensService.GetAll();
            return View(data);
        }

        public ActionResult Create()
        {
            ViewBag.JobList = new SelectList(jobService.GetDropDown(), "Value", "Text");
            return View();
        }

        [HttpPost]
        public ActionResult Create(JobExpensViewModel jobExpensVM)
        {
            jobExpensService.Create(jobExpensVM);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var post = jobExpensService.GetByID(id);
            ViewBag.JobList = new SelectList(jobService.GetDropDown(), "Value", "Text",post.JobId );

            return View(post);
        }

        [HttpPost]
        public ActionResult Edit(JobExpensViewModel jobExpensVM)
        {


            //jobExpensVM.Job  = User.Identity.ToString ;

            jobExpensService.Update(jobExpensVM);

            return RedirectToAction("Index");
        }
    }
}