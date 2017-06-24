using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;


namespace WhatzQ.Controllers
{
    public class SubjectController : Controller
    {
        private WhatzQContext _context;

        public SubjectController()
        {
            _context=new WhatzQContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        // GET: Subject
        public ActionResult Create()
        {
            return View("SubjectForm");
        }

        [HttpPost]
        public ActionResult Save(Subject subject)
        {
            int temp=0;
            foreach (var sub in _context.Subjects.ToList())
            {
                if (subject.ID == sub.ID)
                {
                    temp = sub.ID;
                }
            }

           if (subject.ID != temp)
            {
                _context.Subjects.Add(subject);
            }
            else 
            {
                var subjectInDb = _context.Subjects.Single(s => s.ID == subject.ID);
                //subjectInDb.ID = subject.ID;
                subjectInDb.Description = subject.Description;
            }    
                _context.SaveChanges();
               return RedirectToAction("Index","Database");
            
        }

        public ActionResult EditSub(int id)
        {
            var subject = _context.Subjects.SingleOrDefault(c => c.ID == id);
            if (subject == null)
                return HttpNotFound();
            return View("SubjectForm");
        }
    }
}