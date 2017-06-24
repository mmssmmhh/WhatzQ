using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WhatzQ.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Subject()
        {
            return View("SubjectForm");
        }

        public ActionResult About()
        {
            

            return View("FactorForm");
        }

        public ActionResult Contact()
        {
           

            return View("CriteriaForm");
        }

        public ActionResult QualityMetric()
        {
            return View("QMetricForm");
        }

        public ActionResult Application()
        {
            return View("ApplicationForm");
        }
    }
}