using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WhatzQ.Controllers
{
    public class CriteriaController : Controller
    {
        private WhatzQContext _context;

        public CriteriaController()
        {
            _context = new WhatzQContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Criteria
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Save(Criterion criterion)
        {
            int temp = 0;
            foreach (var crit in _context.Criteria.ToList())
            {
                if (criterion.CriteriaNum == crit.CriteriaNum)
                {
                    temp = crit.CriteriaNum;
                }
            }

            if (criterion.CriteriaNum != temp)
            {
                _context.Criteria.Add(criterion);
            }
            else
            {
                var criterionInDb = _context.Criteria.Single(s => s.CriteriaNum == criterion.CriteriaNum);
                criterionInDb.CriteriaNum = criterion.CriteriaNum;
                criterionInDb.Factor_Id = criterion.Factor_Id;
                criterionInDb.Subject_Id = criterion.Subject_Id;
                criterionInDb.Description = criterion.Description;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Database");

        }

        public ActionResult EditCrit(int id)
        {
            var crit = _context.Criteria.SingleOrDefault(c => c.CriteriaNum == id);
            if (crit == null)
                return HttpNotFound();
            return View("CriteriaForm");
        }
    }
}