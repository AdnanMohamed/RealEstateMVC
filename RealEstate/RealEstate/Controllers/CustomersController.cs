using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Models;
using RealEstate.Repository;

namespace RealEstate.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CustomersRepository customersDB;

        public CustomersController()
        {
            customersDB = new CustomersRepository();
        }
        public string Index()
        {
            return "Hello From Customers!";
        }

        public List<Customer> getAllCustomers()
        {
            return customersDB.getCustomers();
        }
    }
}