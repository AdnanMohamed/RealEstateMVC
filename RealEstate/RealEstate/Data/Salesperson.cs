using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Data
{
    public class Salesperson
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { set; get; }
        public string Name { set; get; }

        public List<Deal> Deals { set; get; } = new List<Deal>();
    }
}
