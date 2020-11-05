using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Data
{
    public class MyCustomersContext : DbContext
    {
        public MyCustomersContext(DbContextOptions<MyCustomersContext> options)
            : base(options)
        {

        }

        public DbSet<Customers> Customers { get; set; }
    }
}
