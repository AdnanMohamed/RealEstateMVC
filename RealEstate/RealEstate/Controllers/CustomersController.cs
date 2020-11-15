using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Models;
using RealEstate.Repository;

namespace RealEstate.Controllers
{
    [Route("[controller]/[action]")]
    public class CustomersController : Controller
    {
        private readonly ICustomersRepository _customersRepository;  // The table of customers

        public CustomersController(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public async Task<ViewResult> GetAllCustomers(bool deletedCustomer = false)
        {
            var allCustomers = await _customersRepository.getCustomers();
            ViewBag.DeletedCustomer = deletedCustomer;
            return View(allCustomers);
        }

        public async Task<CustomerModel> GetCustomer(string id)
        {
            return await _customersRepository.GetCustomer(id);
        }

        [Authorize]
        public ViewResult AddNewCustomer(bool isSuccess = false, string customerId = "")
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.CustomerId = customerId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCustomer(CustomerModel customer)
        {
            if (ModelState.IsValid)
            {
                string id = await _customersRepository.AddNewCustomer(customer);
                return RedirectToAction(nameof(AddNewCustomer), new { isSuccess = true, customerId = id });
            }
            ViewBag.IsSuccess = false;
            ViewBag.CustomerId = customer.Id;
            return View();
        }

        public async Task<ViewResult> UpdateCustomer(string id, bool isSuccess = false)
        {
            ViewBag.IsSuccess = isSuccess;
            CustomerModel customer = await _customersRepository.GetCustomer(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult UpdateCustomer(CustomerModel customer)
        {
            if (ModelState.IsValid)
            {
                _customersRepository.UpdateCustomer(customer);
                return RedirectToAction(nameof(UpdateCustomer), new {id = customer.Id, isSuccess = true });
            }
            ViewBag.IsSuccess = false;
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            ViewBag.DeletedCustomer = await _customersRepository.DeleteCustomer(id);
            return RedirectToAction(nameof(GetAllCustomers), new { deletedCustomer = ViewBag.DeletedCustomer });
        }


    }
}