using RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Repository
{
    public class CustomersRepository
    {

        public CustomersRepository()
        {
            Customers = new List<Customer>()
            {
                new Customer(){Id = 1, Name= "Adnan Mohamed", Email="adnan@gmail.com"},
                new Customer(){Id = 2, Name="Ebraheem Nezar", Email="ibra@gmail.com"},
                new Customer(){Id = 3, Name="Ali Yaseen", Email="ali@gmail.com"},
                new Customer(){Id = 4, Name="Biliardo Davinchi", Email="bil@gmail.com"}
            };
        }
        public List<Customer> getCustomers()
        {
            return Customers;
        }

        public Customer getCustomer(int id)
        {
            return Customers.Where(customer => customer.Id == id).FirstOrDefault();
        }

        private List<Customer> Customers;
    }
}
