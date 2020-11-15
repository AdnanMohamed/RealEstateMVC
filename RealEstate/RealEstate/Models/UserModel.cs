using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Please enter the first name.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Please enter the last name.")]
        [Display(Name = "First Name")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Please enter your email.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your password.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmedPassword", ErrorMessage = "Password mismatch.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please confirm your password.")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmedPassword { get; set; }
    }
}
