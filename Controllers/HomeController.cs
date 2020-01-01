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
        public ActionResult Index()
        {
            return View(db.Patients.ToList());
        }

        public ActionResult ViewList()
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
                    return RedirectToAction("ViewList");
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