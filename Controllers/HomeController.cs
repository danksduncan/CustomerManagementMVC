using MVCPatientApp.Context;
using MVCPatientApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCPatientApp.Controllers
{
    public class HomeController : Controller
    {
        private PatientContext db = new PatientContext();
        private SubscriberContext sbdb = new SubscriberContext();
        //Made new changes

        public ActionResult ViewList()
        {
            return View(db.Patients.ToList());
        }

        [HttpGet]
        public ActionResult HomePage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HomePage(Subscribe subscriber)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    sbdb.Subscriber.Add(subscriber);
                    sbdb.SaveChanges();
                    return RedirectToAction("ViewList");
                }
                return View(subscriber);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Patient patient = db.Patients.Find(id);
            if (patient == null)
                return HttpNotFound();
            return View(patient);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Patient patient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Patients.Add(patient);
                    db.SaveChanges();
                    return RedirectToAction("ViewList");
                }
                return View(patient);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Patient patient = db.Patients.Find(id);
            if (patient == null)
                return HttpNotFound();
            return View(patient);
        }

        [HttpPost]
        public ActionResult Edit(Patient patient, string action)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    switch (action)
                    {
                        case "Save":
                            db.Entry(patient).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                            return RedirectToAction("ViewList");
                        case "Back To List":
                            return RedirectToAction("ViewList");
                    }
                }
                return View(patient);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Patient patient = db.Patients.Find(id);
            if (patient == null)
                return HttpNotFound();
            return View(patient);
        }

        [HttpPost]
        public ActionResult Delete(int? id, string action)
        {
            Patient patient = new Patient();
            if (id != null)
            {
                switch (action)
                {
                    case "Delete":
                        patient = db.Patients.Find(id);
                        db.Patients.Remove(patient);
                        db.SaveChanges();
                        return RedirectToAction("ViewList");
                    case "Back To List":
                        return RedirectToAction("ViewList");
                }
            }
            return View(patient);
        }
    }
}