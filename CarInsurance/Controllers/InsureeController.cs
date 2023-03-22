using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarInsurance.Models;

namespace CarInsurance.Controllers
{
    public class InsureeController : Controller
    {
        private InsuranceEntities db = new InsuranceEntities();

        // GET: Insuree
        public ActionResult Index()
        {
            return View(db.Insurees.ToList());

        
        }

        // GET: Insuree/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // GET: Insuree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insuree/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
        {
            int Id = insuree.Id;
            string FirstName = insuree.FirstName;
            string LastName = insuree.LastName;
            string EmailAddress = insuree.EmailAddress;
            DateTime DateOfBirth = insuree.DateOfBirth;
            int CarYear = insuree.CarYear;
            string CarMake = insuree.CarMake;
            string CarModel = insuree.CarModel;
            bool DUI = insuree.DUI;
            int SpeedingTickets = insuree.SpeedingTickets;
            bool CoverageType = insuree.CoverageType;
            decimal Qoute = insuree.Quote;

            CarMake = CarMake.ToLower(); 
            decimal QouteDefault = 50.00m;
            Qoute = QouteDefault;
            double age = (DateTime.Now - DateOfBirth).TotalDays / 365.242199; 

            if(age <= 18)
            {
                Qoute += 100.00m;
            }

            if((age > 19 ) && (age <25)) 
            {
                Qoute += 50.00m; 
            }

            if(age > 25)
            {
                Qoute += 25.00m;
            }


            if (CarYear < 2000)
            {
                Qoute += 25.00m;
            }


            if (CarYear < 2015)
            {
                Qoute += 25.00m;
            }

            if (CarMake == "porsche")
            {
                Qoute += 25.00m;
            }

            if ((CarMake == "porsche") && (CarModel == "911 Carrera"))
            {
                Qoute += 25.00m;
            }

            if(SpeedingTickets > 0)
            {
                Qoute += (SpeedingTickets * 10.00m);
            }

            if(DUI = true)
            {
                Qoute += (Qoute * 25 / 100);
            }

            if(CoverageType = true)
            {
                Qoute += (Qoute * 50 / 100);
            }

           

            if (ModelState.IsValid)
            {
                db.Insurees.Add(insuree);
                db.SaveChanges();
               // return RedirectToAction("Index");
            }





            return View(insuree);
        }

        
            



        // GET: Insuree/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insuree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insuree);
        }

        // GET: Insuree/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insuree insuree = db.Insurees.Find(id);
            db.Insurees.Remove(insuree);
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
