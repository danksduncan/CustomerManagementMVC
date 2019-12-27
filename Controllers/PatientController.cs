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

        // GET: Patient
        public ActionResult Index()
        {
            return View(db.Patients.ToList());
        }

        // GET: Patient/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Patient patient = db.Patients.Find(id);
            if (patient == null)
                return HttpNotFound();
            return View(patient);
        }

        // GET: Patient/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patient/Create
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

        // GET: Patient/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Patient patient = db.Patients.Find(id);
            if (patient == null)
                return HttpNotFound();
            return View(patient);
        }

        // POST: Patient/Edit/5
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

        // GET: Patient/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Patient patient = db.Patients.Find(id);
            if (patient == null)
                return HttpNotFound();
            return View(patient);
        }

        // POST: Patient/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, Patient pat)
        {
            try
            {
                Patient patient = new Patient();
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    patient = db.Patients.Find(id);
                    if (patient == null)
                        return HttpNotFound();
                    db.Patients.Remove(patient);
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
    }
}
