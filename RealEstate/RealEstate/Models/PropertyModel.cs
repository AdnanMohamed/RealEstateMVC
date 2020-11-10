using RealEstate.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Models
{
    public class PropertyModel
    {
        [Required(ErrorMessage = "The Property ID is mandatory.")]
        public string Id { get; set; }

        [Required(ErrorMessage = "The Property Type is mandatory.")]
        public string PropertyType { get; set; }
        public string Location { get; set; }
        public string LocationURL { get; set; }

        [Required(ErrorMessage = "The Property must have an owner.")]
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
    }
}
