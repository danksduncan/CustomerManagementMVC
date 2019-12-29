using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPatientApp.Models
{
    public class Patient
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter first name of patient.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter last name of patient.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter patient comments")]
        public string Comments { get; set; }
    }
}