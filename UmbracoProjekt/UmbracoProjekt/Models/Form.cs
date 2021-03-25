using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UmbracoProjekt.Models
{
    public class Form
    {
        public int Id { get; set; }
        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress, MaxLength(500), Display(Name = "Email Adress")]
        public string EmailAdress { get; set; }
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }
    }
}
