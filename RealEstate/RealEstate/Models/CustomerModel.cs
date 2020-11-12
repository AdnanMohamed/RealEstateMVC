using RealEstate.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Models
{
    public class CustomerModel
    {
        [Required(ErrorMessage = "Please Enter the Customer's CPR")]
        [RegularExpression("[0-9]{9}", ErrorMessage = "This CPR is Invalid.")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Please Enter the Customer's Full Name")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [RegularExpression("[0-9]{8}", ErrorMessage = "This Phone Number is Invalid.")]
        public string Phone { get; set; }
    }
}
