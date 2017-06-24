using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WhatzQ.Controllers
{
    public class QualityMetricController : Controller
    {
        // GET: QualityMetric
        public ActionResult Index()
        {
            return View();
        }
        private WhatzQContext _context;

        public QualityMetricController()
        {
            _context = new WhatzQContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        [HttpPost]
        public ActionResult Save(QualityMetric qualityMetric)
        {
            int temp = 0;
            foreach (var qmetric in _context.QualityMetrics.ToList())
            {
                if (qualityMetric.MetricNum == qmetric.MetricNum)
                {
                    temp = qmetric.MetricNum;
                }
            }

            if (qualityMetric.MetricNum!= temp)
            {
                _context.QualityMetrics.Add(qualityMetric);
            }
            else
            {
                var qmterInDb = _context.QualityMetrics.Single(s => s.MetricNum == qualityMetric.MetricNum);
                qmterInDb.MetricNum = qualityMetric.MetricNum;
                qmterInDb.Criteria_Id = qualityMetric.Criteria_Id;
                qmterInDb.Factor_Id = qualityMetric.Factor_Id;
                qmterInDb.Subject_Id = qualityMetric.Subject_Id;
                qmterInDb.Description = qualityMetric.Description;
                qmterInDb.TypeofMetric = qualityMetric.TypeofMetric;
                qmterInDb.TypesofValue = qualityMetric.TypesofValue;
                qmterInDb.TypeofQualifiration = qualityMetric.TypeofQualifiration;
                qmterInDb.RelationofMetric = qualityMetric.RelationofMetric;
                qmterInDb.RatedBased = qualityMetric.RatedBased;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Database");

        }

        public ActionResult EditMetric(int id)
        {
            var qmetric = _context.QualityMetrics.SingleOrDefault(c => c.MetricNum == id);
            if (qmetric == null)
                return HttpNotFound();
            return View("QMetricForm");
        }
    }
}