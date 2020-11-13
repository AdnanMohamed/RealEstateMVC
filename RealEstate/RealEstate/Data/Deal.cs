using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Data
{
    public class Deal
    {
        public string Id { set; get; }
        public string SalespersonId { set; get; }
        public string CustomerId { set; get; }
        public string PropertyId { set; get; }
        public decimal Price { set; get; }
        public decimal Commission { set; get; }
        public DateTime CreatedOn { set; get; }

        public Property Property { set; get; }
        public Customer Customer { set; get; }
        public Salesperson Salesperson { set; get; }
    }
}
