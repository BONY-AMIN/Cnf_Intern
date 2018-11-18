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
    public class UserProfileController : Controller
    {
        private UnitOfWork unitOfWork;
        private UserProfileService userProfileService;
        private BranchService branchService;


        public UserProfileController()
        {
            unitOfWork = new UnitOfWork();
            userProfileService = new UserProfileService(unitOfWork);
            branchService = new BranchService(unitOfWork);
        }

        public ActionResult Index()
        {
            var data = userProfileService.GetAll();
            return View(data);
        }

        public ActionResult Create()
        {
            ViewBag.BranchList = new SelectList(branchService.GetDropDown(), "Value", "Text");

            return View();
        }

        [HttpPost]
        public ActionResult Create(UserProfileViewModel userProfileVM)
        {
            userProfileService.Create(userProfileVM);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            var post = userProfileService.GetByID(id);

            ViewBag.BranchList = new SelectList(branchService.GetDropDown(), "Value", "Text",post.BranchId);

            return View(post);
        }

        [HttpPost]
        public ActionResult Edit(UserProfileViewModel userProfileVM)
        {


            //userProfileVM.Branch  = User.Identity.Name;

            userProfileService.Update(userProfileVM);

            return RedirectToAction("Index");
        }
    }
}