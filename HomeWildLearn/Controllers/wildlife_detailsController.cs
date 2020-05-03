using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeWildLearn.Models;
using Rotativa;


namespace HomeWildLearn.Controllers
{
    public class wildlife_detailsController : Controller
    {
        private AnimalModel2 db = new AnimalModel2();

        // GET: wildlife_details
        public ActionResult Index()
        {
            return View(db.wildlife_details.ToList());
        }

        // GET: wildlife_details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wildlife_details wildlife_details = db.wildlife_details.Find(id);
            if (wildlife_details == null)
            {
                return HttpNotFound();
            }
            return View(wildlife_details);
        }

        //Method to export the details of an animal
        public ActionResult ExportPDF(String id)
        {
            return new Rotativa.ActionAsPdf("Details/" + id);
        }

        //public ActionResult ExportPDF(String id)
        //{
        //    return new Rotativa.ViewAsPdf("Details/" + id);
        //}

        //// GET: wildlife_details/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: wildlife_details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Animal_id,Fact_1,Fact_2,Animal_Sound,Animal_Image_Main,Animal_Image_1,Animal_Image_2,Animal_Image_3,Animal_Image_4,Animal_Image_5")] wildlife_details wildlife_details)
        {
            if (ModelState.IsValid)
            {
                db.wildlife_details.Add(wildlife_details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wildlife_details);
        }

        // GET: wildlife_details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wildlife_details wildlife_details = db.wildlife_details.Find(id);
            if (wildlife_details == null)
            {
                return HttpNotFound();
            }
            return View(wildlife_details);
        }

        // POST: wildlife_details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Animal_id,Fact_1,Fact_2,Animal_Sound,Animal_Image_Main,Animal_Image_1,Animal_Image_2,Animal_Image_3,Animal_Image_4,Animal_Image_5")] wildlife_details wildlife_details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wildlife_details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wildlife_details);
        }

        // GET: wildlife_details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wildlife_details wildlife_details = db.wildlife_details.Find(id);
            if (wildlife_details == null)
            {
                return HttpNotFound();
            }
            return View(wildlife_details);
        }

        // POST: wildlife_details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            wildlife_details wildlife_details = db.wildlife_details.Find(id);
            db.wildlife_details.Remove(wildlife_details);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
