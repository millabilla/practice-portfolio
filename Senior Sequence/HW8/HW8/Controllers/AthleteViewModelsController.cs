//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using HW8.Models;

//namespace HW8.Models.ViewModels
//{
//    public class AthleteViewModelsController : Controller
//    {
//        private TracknFieldContext db = new TracknFieldContext();

//        // GET: AthleteViewModels
//        // GET: Athletes
//        public ActionResult Index() {
//            //var athletes = db.Athletes.Include(a => a.Team);
//            return View(db.Athletes.ToList());
//        }

//        // GET: AthleteViewModels/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Athlete athlete = db.Athletes.Find(id);
//            if (athlete == null)
//            {
//                return HttpNotFound();

//            }
            
//            AthleteViewModel athleteViewModel = new AthleteViewModel(athlete);
//            return View(athleteViewModel);
//        }

//        // GET: AthleteViewModels/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: AthleteViewModels/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "AthleteID,Name,RaceTime,MeetDate,Distance")] AthleteViewModel athleteViewModel)
//        {
//            if (ModelState.IsValid)
//            {
//                db.AthleteViewModels.Add(athleteViewModel);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(athleteViewModel);
//        }

//        // GET: AthleteViewModels/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            AthleteViewModel athleteViewModel = db.AthleteViewModels.Find(id);
//            if (athleteViewModel == null)
//            {
//                return HttpNotFound();
//            }
//            return View(athleteViewModel);
//        }

//        // POST: AthleteViewModels/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "AthleteID,Name,RaceTime,MeetDate,Distance")] AthleteViewModel athleteViewModel)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(athleteViewModel).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(athleteViewModel);
//        }

//        // GET: AthleteViewModels/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            AthleteViewModel athleteViewModel = db.AthleteViewModels.Find(id);
//            if (athleteViewModel == null)
//            {
//                return HttpNotFound();
//            }
//            return View(athleteViewModel);
//        }

//        // POST: AthleteViewModels/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            AthleteViewModel athleteViewModel = db.AthleteViewModels.Find(id);
//            db.AthleteViewModels.Remove(athleteViewModel);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
