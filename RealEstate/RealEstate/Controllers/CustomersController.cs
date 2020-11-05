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
        private readonly CustomersRepository _customersDB;  // The table of customers

        public CustomersController(CustomersRepository customersDB)
        {
            _customersDB = customersDB;
        }

        public async Task<ViewResult> GetAllCustomers()
        {
            var data = await _customersDB.getCustomers();
            return View(data);
        }

        public ViewResult AddNewCustomer(bool isSuccess = false, string customerId = "")
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.CustomerId = customerId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCustomer(CustomerModel customer)
        {
            string id = await _customersDB.AddNewCustomer(customer);
            return RedirectToAction(nameof(AddNewCustomer), new { isSuccess = true, customerId = id });
        }
    }
}