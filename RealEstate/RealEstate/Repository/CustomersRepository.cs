using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Repository
{
    public class CustomersRepository
    {
        private readonly MyCustomersContext _context = null;

        public CustomersRepository(MyCustomersContext context)
        {
            _context = context;
        }

        public async Task<string> AddNewCustomer(CustomerModel model)
        {
            var newCustomer = new Customers()
            {
                Id = model.Id,
                Email = model.Email,
                Phone = model.Phone,
                Name = model.Name
            };

            await _context.Customers.AddAsync(newCustomer);
            await _context.SaveChangesAsync();

            return newCustomer.Id;

        }
        public async Task<List<CustomerModel>> getCustomers()
        {
            var customers = new List<CustomerModel>();
            var allCustomers = await _context.Customers.ToListAsync();
            if(allCustomers?.Any() == true)
            {
                foreach (var customer in allCustomers)
                {
                    customers.Add(new CustomerModel()
                    {
                        Id = customer.Id,
                        Name = customer.Name,
                        Email = customer.Email,
                        Phone = customer.Phone
                    });
                }
            }
            return customers;
        }

        public CustomerModel getCustomer(string id)
        {
            return DataSource().Where(customer => customer.Id == id).FirstOrDefault();
        }

        private List<CustomerModel> DataSource()
        {
            return new List<CustomerModel>()
            {
                new CustomerModel(){Id="32434", Name="Adnan Mohamed", Email="adnan@gmail.com", Phone="2345345"}
            };
        }
    }
}
