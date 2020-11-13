using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Models
{
    public class DealModel
    {
        [Required(ErrorMessage = "The Deal should have an ID.")]
        public string Id { set; get; }
        [Required(ErrorMessage = "Salesperson is required.")]
        public string SalespersonId { set; get; }
        public string Salesperson { set; get; }
        [Required(ErrorMessage = "Buyer is required.")]
        public string CustomerId { set; get; }
        public string Customer { set; get; }
        [Required(ErrorMessage = "Property is required.")]
        public string PropertyId { set; get; }
        //public string SellerId { set; get; }
        [Required(ErrorMessage = "Price is required.")]
        [Range(1, 999999999)]
        public decimal Price { set; get; }
        [Required(ErrorMessage = "Commission is required.")]
        [Range(0, 50)]
        public decimal Commission { set; get; }
        public string Date { set; get; }
    }
}
