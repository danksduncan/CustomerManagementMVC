using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCPatientApp.Models
{
    public class Subscribe
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter your name.")]
        [Display(Name = "Your Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter your email.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Your E-mail")]
        public string EmailAddress { get; set; }
    }
}