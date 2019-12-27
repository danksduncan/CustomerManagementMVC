using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPatientApp.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Comments { get; set; }
    }
}