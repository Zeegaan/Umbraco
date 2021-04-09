using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Draw
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
        [Required, Range(18, 200, ErrorMessage ="You must be a valid age over 18 to enter this draw")]
        public int Age { get; set; }
    }
}
