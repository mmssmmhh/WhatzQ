using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WhatzQ.Controllers
{
    public class ApplicationController : Controller
    {
        // GET: Application
        public ActionResult Index()
        {
            return View();
        }
        private WhatzQContext _context;

        public ApplicationController()
        {
            _context = new WhatzQContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        [HttpPost]
        public ActionResult Save(Application application)
        {
            int temp = 0;
            foreach (var app in _context.Applications.ToList())
            {
                if (application.AppID == app.AppID)
                {
                    temp = app.AppID;
                }
            }

            if (application.AppID != temp)
            {
                _context.Applications.Add(application);
            }
            else
            {
                var applicationInDb = _context.Applications.Single(s => s.AppID == application.AppID);
                applicationInDb.AppID = application.AppID;
                applicationInDb.SubjectID = application.SubjectID;
                applicationInDb.FNum = application.FNum;
                applicationInDb.CNum = application.CNum;
                applicationInDb.MNum = application.MNum;
                applicationInDb.QValue = application.QValue;
                applicationInDb.UsesValue = application.UsesValue;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Database");

        }

        public ActionResult EditApp(int id)
        {
            var app = _context.Applications.SingleOrDefault(c => c.AppID == id);
            if (app == null)
                return HttpNotFound();
            return View("ApplicationForm");
        }
    }
}