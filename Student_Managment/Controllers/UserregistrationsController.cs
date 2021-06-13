using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Student_Managment.Models;

namespace Student_Managment.Controllers
{
   
    public class UserregistrationsController : Controller
    {
        private UserDBEntities db = new UserDBEntities();

        // GET: Userregistrations
        public ActionResult Index()
        {
            var userregistrations = db.userregistrations.Include(u => u.city1).Include(u => u.country1).Include(u => u.state1);
            return View(userregistrations.ToList());
        }

        // GET: Userregistrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userregistration userregistration = db.userregistrations.Find(id);
            if (userregistration == null)
            {
                return HttpNotFound();
            }
            return View(userregistration);
        }

        // GET: Userregistrations/Create
        public ActionResult Create()
        {
            var list = new List<string>() { "Male", "Female", "Others" };
            ViewBag.list = list;
            ViewBag.city = new SelectList(db.cities, "cityid", "cityname");
            ViewBag.country = new SelectList(db.countries, "countryid", "countryname");
            ViewBag.state = new SelectList(db.states, "stateid", "statename");
            return View();
        }

        // POST: Userregistrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "registrationid,firstname,middlename,lastname,gender,dob,login,password,country,state,city,email,phoneno")] userregistration userregistration)
        {
            if (ModelState.IsValid)
            {
                db.userregistrations.Add(userregistration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.city = new SelectList(db.cities, "cityid", "cityname", userregistration.city);
            ViewBag.country = new SelectList(db.countries, "countryid", "countryname", userregistration.country);
            ViewBag.state = new SelectList(db.states, "stateid", "statename", userregistration.state);
            return View(userregistration);
        }

        // GET: Userregistrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userregistration userregistration = db.userregistrations.Find(id);
            if (userregistration == null)
            {
                return HttpNotFound();
            }
            ViewBag.city = new SelectList(db.cities, "cityid", "cityname", userregistration.city);
            ViewBag.country = new SelectList(db.countries, "countryid", "countryname", userregistration.country);
            ViewBag.state = new SelectList(db.states, "stateid", "statename", userregistration.state);
            return View(userregistration);
        }

        // POST: Userregistrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "registrationid,firstname,middlename,lastname,gender,dob,login,password,country,state,city,email,phoneno")] userregistration userregistration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userregistration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.city = new SelectList(db.cities, "cityid", "cityname", userregistration.city);
            ViewBag.country = new SelectList(db.countries, "countryid", "countryname", userregistration.country);
            ViewBag.state = new SelectList(db.states, "stateid", "statename", userregistration.state);
            return View(userregistration);
        }

        // GET: Userregistrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userregistration userregistration = db.userregistrations.Find(id);
            if (userregistration == null)
            {
                return HttpNotFound();
            }
            return View(userregistration);
        }

        // POST: Userregistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            userregistration userregistration = db.userregistrations.Find(id);
            db.userregistrations.Remove(userregistration);
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
