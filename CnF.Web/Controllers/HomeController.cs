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
   [Authorize ]
    public class HomeController : Controller
    {
        private UnitOfWork unitOfWork;
        private NotificationService notificationService;
        private WidgetService widgetService;
        

        public HomeController()
        {
            unitOfWork = new UnitOfWork();

            notificationService = new NotificationService(unitOfWork );
            widgetService = new WidgetService(unitOfWork);
        }

        public ActionResult Index()
        {
            Session["notifications"] = notificationService.GetNotification();


            ViewBag.widget = widgetService.GetWidgetAmount();
            ViewBag.value = widgetService.GetWidgetValue();

            Session["active"] = widgetService.ActiveJob();

            Session["done"] = widgetService.CompleteJob();

            Session["coming"] = widgetService.UpcomingJob ();



            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}