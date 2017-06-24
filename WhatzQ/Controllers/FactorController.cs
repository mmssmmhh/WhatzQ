using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WhatzQ.Controllers
{
    public class FactorController : Controller
    {
        private WhatzQContext _context;

        public FactorController()
        {
            _context = new WhatzQContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Factor
        public ViewResult Index()
        {
            var factor = _context.Factors.ToList();
            return View(factor);
        }

        [HttpPost]
        public ActionResult Save(Factor factor)
        {
            int temp = 0;
            foreach (var fact in _context.Factors.ToList())
            {
                if (factor.FactNum == fact.FactNum)
                {
                    temp = fact.FactNum;
                }
            }

            if (factor.FactNum != temp)
            {
                _context.Factors.Add(factor);
            }
            else
            {
                var factorInDb = _context.Factors.Single(s => s.FactNum == factor.FactNum);
                factorInDb.FactNum = factor.FactNum;
                factorInDb.Subject_Id = factor.Subject_Id;
                factorInDb.Description = factor.Description;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Database");

        }

        public ActionResult EditFact(int id)
        {
            var factor = _context.Factors.SingleOrDefault(c => c.FactNum == id);
            if (factor == null)
                return HttpNotFound();
            return View("FactorForm");
        }
    }
}
