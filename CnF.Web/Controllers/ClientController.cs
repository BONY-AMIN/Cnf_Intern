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
    public class ClientController : Controller
    {
        private UnitOfWork unitOfWork;
        private ClientService clientService;
        private BranchService branchService;


        public ClientController()
        {
            unitOfWork = new UnitOfWork();
            clientService = new ClientService(unitOfWork);
            branchService = new BranchService(unitOfWork);
        }

        public ActionResult Index()
        {
            var data = clientService.GetAll();
            return View(data);
            
        }

        public ActionResult Create()
        {
            ViewBag.BranchList = new SelectList(branchService.GetDropDown(), "Value", "Text");
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClientViewModel clientVM)
        {
            clientService.Create(clientVM);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var post = clientService.GetByID(id);
            ViewBag.BranchList = new SelectList(branchService.GetDropDown(), "Value", "Text",post.BranchId );

            return View(post);
        }

        [HttpPost]
        public ActionResult Edit(ClientViewModel clientVM)
        {


            //clientVM.Name = User.Identity.Name;

            clientService.Update(clientVM);

            return RedirectToAction("Index");
        }
    }
}