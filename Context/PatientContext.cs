using MVCPatientApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCPatientApp.Context
{
    public class PatientContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
    }

}