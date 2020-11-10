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
            var allCustomers = await _customersDB.getCustomers();
            return View(allCustomers);
        }

        public async Task<CustomerModel> GetCustomer(string id)
        {
            return await _customersDB.GetCustomer(id);
        }
        public ViewResult AddNewCustomer(bool isSuccess = false, string customerId = "")
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.CustomerId = customerId;
            return View();
        }

        public async Task<ViewResult> UpdateCustomer(string id, bool isSuccess = false)
        {
            ViewBag.IsSuccess = isSuccess;
            CustomerModel customer = await _customersDB.GetCustomer(id);
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCustomer(CustomerModel customer)
        {
            if (ModelState.IsValid)
            {
                string id = await _customersDB.AddNewCustomer(customer);
                return RedirectToAction(nameof(AddNewCustomer), new { isSuccess = true, customerId = id });
            }
            ViewBag.IsSuccess = false;
            ViewBag.CustomerId = customer.Id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            await _customersDB.DeleteCustomer(id);
            return RedirectToAction(nameof(GetAllCustomers));
        }

        [HttpPost]
        public IActionResult UpdateCustomer(CustomerModel customer)
        {
            if (ModelState.IsValid)
            {
                _customersDB.UpdateCustomer(customer);
                return RedirectToAction(nameof(UpdateCustomer), new { isSuccess = true });
            }
            ViewBag.IsSuccess = false;
            return View(customer);
        }
    }
}