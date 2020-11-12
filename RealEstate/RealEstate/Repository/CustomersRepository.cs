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
        private readonly RealEstateContext _context = null;

        public CustomersRepository(RealEstateContext context)
        {
            _context = context;
        }

        public async Task<string> AddNewCustomer(CustomerModel model)
        {
            var newCustomer = new Customer()
            {
                Id = model.Id,
                Email = model.Email,
                Phone = model.Phone,
                Name = model.Name,
                Deals = new List<Deal>()
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
                        Phone = customer.Phone,
                    });
                }
            }
            return customers;
        }

        public async Task<CustomerModel> GetCustomer(string id)
        {
            var cust = await _context.Customers.FindAsync(id);
            return new CustomerModel()
            {
                Id = cust.Id,
                Name = cust.Name,
                Email = cust.Email,
                Phone = cust.Phone,
            };
        }

        public async Task<bool> DeleteCustomer(string id)
        {
            var cust = await _context.Customers.FindAsync(id);
            if (cust != null && cust.Deals.Count == 0)
            {
                _context.Customers.Remove(cust);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public void UpdateCustomer(CustomerModel customerModel)
        {
            var customer = new Customer()
            {
                Id = customerModel.Id,
                Name = customerModel.Name,
                Email = customerModel.Email,
                Phone = customerModel.Phone,
            };
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

    }
}
