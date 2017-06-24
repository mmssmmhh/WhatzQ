using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WhatzQ.Controllers
{
    public class DatabaseController : Controller
    {
        private WhatzQContext _context;

        public DatabaseController()
        {
            _context = new WhatzQContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Subject
        public ViewResult Index()
        {
            ViewBag.Message = "Full Database";
            dynamic mymodel = new ExpandoObject();
            mymodel.Subjects = _context.Subjects.ToList();
            mymodel.Factors = _context.Factors.ToList();
            mymodel.Criteria = _context.Criteria.ToList();
            mymodel.QualityMetrics = _context.QualityMetrics.ToList();
            mymodel.ApplicationTable = _context.Applications.ToList();
            return View(mymodel);

        }


    }
}