using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Models
{
    public class DealModel
    {
        public string Id { set; get; }
        public int SalespersonId { set; get; }
        public string Salesperson { set; get; }
        public string CustomerId { set; get; }
        public string Customer { set; get; }
        public string PropertyId { set; get; }
        public string Seller { set; get; }
        public decimal Price { set; get; }
        public decimal Commission { set; get; }
    }
}
