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

        [Required(ErrorMessage = "Enter birthday of patient.")]
        [DataType(DataType.Date)]
        public string Birthday { get; set; }

        [Required(ErrorMessage = "Enter email of patient.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Enter phone number of patient.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Enter the insurance company of patient.")]
        [Display(Name = "Insurance Company")]
        public string InsuranceCompany { get; set; }

        [Required(ErrorMessage = "Enter comments on patient.")]
        [Display(Name = "Additional Comments")]
        public string AdditionalComments { get; set; }

        [Required(ErrorMessage = "Enter the current date.")]
        [DataType(DataType.Date)]
        [Display(Name = "Today's Date")]
        public string CurrentDate { get; set; }
    }
}