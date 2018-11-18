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
    public class BranchController : Controller
    {
        private UnitOfWork unitOfWork;
        private BranchService branchService;


        public BranchController()
        {
            unitOfWork = new UnitOfWork();
            branchService = new BranchService(unitOfWork);
        }

        public ActionResult Index()
        {
            var data = branchService.GetAll();
            return View(data);

        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(BranchViewModel branchVM)
        {
            branchService.Create(branchVM);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var post = branchService.GetByID(id);

            return View(post);
        }

        [HttpPost]
        public ActionResult Edit(BranchViewModel branchVM)
        {


            //branchVM.Name = User.Identity.Name;

            branchService.Update(branchVM);

            return RedirectToAction("Index");
        }
    }
}