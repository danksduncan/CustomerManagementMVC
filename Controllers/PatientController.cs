using MVCPatientApp.Context;
using MVCPatientApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace MVCPatientApp.Controllers
{
    public class PatientController : Controller
    {
        private PatientContext db = new PatientContext();

        public ActionResult Index()
        {
            return View(db.Patients.ToList());
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
                    return RedirectToAction("Index");
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
        public ActionResult Edit(Patient patient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(patient).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
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
        public ActionResult Delete(int? id, Patient pat)
        {
            Patient patient = new Patient();
            if (id != null)
            {
                patient = db.Patients.Find(id);
                db.Patients.Remove(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }
    }
}
