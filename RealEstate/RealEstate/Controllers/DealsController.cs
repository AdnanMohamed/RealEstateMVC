using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RealEstate.Models;
using RealEstate.Repository;

namespace RealEstate.Controllers
{
    public class DealsController : Controller
    {
        private readonly PropertiesRepository propertiesDB;
        private readonly CustomersRepository customersDB;
        private readonly SalespeopleRepository salespeopleDB;
        private readonly DealsRepository dealsDB;
        public DealsController(PropertiesRepository propertiesRepository,
                               CustomersRepository customersRepository,
                               SalespeopleRepository salespeopleRepository,
                               DealsRepository dealsRepository)
        {
            propertiesDB = propertiesRepository;
            customersDB = customersRepository;
            salespeopleDB = salespeopleRepository;
            dealsDB = dealsRepository;
        }

        public async Task<ViewResult> GetAllDeals()
        {
            var allDeals = await dealsDB.GetDeals();
            return View(allDeals);
        }

        public async Task<ViewResult> AddNewDeal(bool isSuccess = false, string dealId = "")
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.DealId = dealId;
            // Getting the Customers from the DB for 'Buyer' drop-down
            ViewBag.Customers = new SelectList(await customersDB.getCustomers(), "Id", "Name");
            // Getting the Properties from the DB for 'Property' drop-down
            ViewBag.Properties = new SelectList(await propertiesDB.GetAllProperties(), "Id", "Id");
            // Getting the Salespeople from the DB for 'Salesperson' drop-down
            ViewBag.Salespeople = new SelectList(await salespeopleDB.GetSalespeople(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewDeal(DealModel dealModel)
        {
            // Getting the Customers from the DB for 'Buyer' drop-down
            ViewBag.Customers = new SelectList(await customersDB.getCustomers(), "Id", "Name");
            // Getting the Properties from the DB for 'Property' drop-down
            ViewBag.Properties = new SelectList(await propertiesDB.GetAllProperties(), "Id", "Id");
            // Getting the Salespeople from the DB for 'Salesperson' drop-down
            ViewBag.Salespeople = new SelectList(await salespeopleDB.GetSalespeople(), "Id", "Name");

            if (ModelState.IsValid)
            {
                string id = await dealsDB.AddNewDeal(dealModel);
                return RedirectToAction(nameof(AddNewDeal), new { isSuccess = true, dealId = id });
            }
            ViewBag.IsSuccess = false;
            ViewBag.DealId = dealModel.Id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDeal(string id)
        {
            await dealsDB.DeleteDeal(id);
            return RedirectToAction(nameof(GetAllDeals));
        }
    }
}