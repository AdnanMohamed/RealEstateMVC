using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Data
{
    public class Salesperson
    {
        public int Id { set; get; }
        public string Name { set; get; }

        public List<Deal> Deals { set; get; } = new List<Deal>();
    }
}
