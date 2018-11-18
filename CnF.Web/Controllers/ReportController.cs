using Chart.Mvc.ComplexChart;
using CnF.Core.Services;
using CnF.Domain.Repositories;
using CnF.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
namespace CnF.Web.Controllers
{
    public class ReportController : Controller
    {
        private UnitOfWork unitOfWork;
        private ReportService reportService;
        //private object myList;

        public ReportController()
        {
            unitOfWork = new UnitOfWork();
            reportService = new ReportService(unitOfWork);
            
        }


        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ClientStatus()
        {
            var data = reportService.GetClientStatus();

            ViewBag.xAxis = data.Select(x => x.JobNo ).ToList();
            ViewBag.yAxis = data.Select(x => x.TotalValue).ToList();

            return View(data);
           
        }
        public ActionResult BillingStatus()
        {
            var data = reportService.GetBillingStatus();

            ViewBag.xAxis = data.Select(x => x.BillNo  ).ToList();
            ViewBag.yAxis = data.Select(x => x.Amount ).ToList();

            return View(data);

        }


        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            BillingStatusViewModel billing =reportService.Details( id  );
            if (billing == null)
            {
                return HttpNotFound();
            }
            return View(billing);
       
        }





        public ActionResult Revenue()
        {
            var data = reportService.GetRevenue();

            ViewBag.Total = data .Sum(x => x.Amount );
            //double total = myList.Sum(item => item.Amount);

             ViewBag.xAxis = data.Select(x => x.JobNo).ToList();
            ViewBag.yAxis = data.Select(x => x.Amount ).ToList();

            return View(data);

        }

    }
}