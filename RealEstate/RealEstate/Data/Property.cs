using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Data
{
    public class Property
    {
        public string Id { get; set; }
        public string PropertyType { get; set; }
        public string Location { get; set; }
        public string LocationURL { get; set; }
        public string CustomerId { get; set; }
        //public string CustomerName { get; set; }
        public ICollection<Deal> Deals { get; set; }
    }
}
