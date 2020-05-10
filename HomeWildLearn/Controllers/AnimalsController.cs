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
    public class AnimalsController : Controller
    {
        private AnimalModel db = new AnimalModel();

        // GET: Animals
        public ActionResult Index()
        {
            return View(db.Animals.ToList());
        }

        // GET: Animals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }


        //public ActionResult ExportPDF(String id)
        //{
        //    Dictionary<string, string> cookieCollection = new Dictionary<string, string>();
        //    foreach (var key in Request.Cookies.AllKeys)
        //    {
        //        cookieCollection.Add(key, Request.Cookies.Get(key).Value);
        //    }
        //    return new Rotativa.ActionAsPdf("Details/" + id)
        //    {
        //        FileName = Server.MapPath("~/Content/Det.pdf"),
        //        Cookies = cookieCollection
        //    };
        //}

        //Method to export the details of an animal
        public ActionResult ExportPDF(String id)
        {
            return new Rotativa.ActionAsPdf("Details/" + id);
        }


        //// GET: Animals/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Animals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "animal_id,animal_name")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Animals.Add(animal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(animal);
        }

        // GET: Animals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: Animals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "animal_id,animal_name")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(animal);
        }

        // GET: Animals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Animal animal = db.Animals.Find(id);
            db.Animals.Remove(animal);
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


        /// <summary>
        /// This method return the entities based on the search term
        /// </summary>
        public ActionResult Search(string term)
        {
            var animalNames = db.Animals.Where(p => p.animal_name.Contains(term)).Select(p => p.animal_name).ToList();
            return Json(animalNames, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// This method return the entities based on the search term
        /// </summary>
        [HttpPost]
        public ActionResult Details(string animalName)
        {
            TempData["shortMessage"] =  "Animal: " + animalName;
            //return RedirectToAction("ExploreSearch", "Home");
            var animalId = db.Animals.Where(p => p.animal_name.Equals(animalName)).Select(p => p.animal_id).ToList();
            var animal = db.Animals.Find(animalId[0]);
            return View(animal);
        }
    }
}
