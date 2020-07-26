using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HW8.Models;
using HW8.Models.ViewModels;

namespace HW8.Controllers {
    public class AthletesController : Controller {
        private TracknFieldContext db = new TracknFieldContext();

        // GET: Athletes
        public ActionResult Index() {
            var athletes = db.Athletes.Include(a => a.Team);
            return View(athletes.ToList());
        }

        // GET: Athletes/Details/5
        public ActionResult Details(int? id) {

            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Athlete athlete = db.Athletes.Find(id);

            if (athlete == null) {
                return HttpNotFound();

            }

            AthleteViewModel athleteViewModel = new AthleteViewModel(athlete);
            

            return View(athleteViewModel);
        }

        public ActionResult graphAth(int? id) {
            Athlete athlete = db.Athletes.Find(id);
            var data = new {
                num = (int)id,
                times = athlete.Events.Select(t => t.RaceTimes),
                dates = athlete.Events.Select(l => l.Location).Select(d => d.Date)
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // GET: Athletes/Create
        public ActionResult Create() {
            ViewBag.TeamID = new SelectList(db.Teams, "ID", "Name");
            return View();
        }

        // POST: Athletes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Gender,TeamID")] Athlete athlete) {
            if (ModelState.IsValid) {
                db.Athletes.Add(athlete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamID = new SelectList(db.Teams, "ID", "Name", athlete.TeamID);
            return View(athlete);
        }

        // GET: Athletes/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Athlete athlete = db.Athletes.Find(id);
            if (athlete == null) {
                return HttpNotFound();
            }
            ViewBag.TeamID = new SelectList(db.Teams, "ID", "Name", athlete.TeamID);
            return View(athlete);
        }
    }
}
