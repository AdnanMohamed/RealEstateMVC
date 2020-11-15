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
    [Route("[controller]/[action]")]
    public class DealsController : Controller
    {
        private readonly IPropertiesRepository propertiesDB;
        private readonly ICustomersRepository customersDB;
        private readonly ISalespeopleRepository salespeopleDB;
        private readonly IDealsRepository dealsDB;
        public DealsController(IPropertiesRepository propertiesRepository,
                               ICustomersRepository customersRepository,
                               ISalespeopleRepository salespeopleRepository,
                               IDealsRepository dealsRepository)
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

        public async Task<ViewResult> UpdateDeal(string id, bool isSuccess = false)
        {
            // Getting the Customers from the DB for 'Buyer' drop-down
            ViewBag.Customers = new SelectList(await customersDB.getCustomers(), "Id", "Name");
            // Getting the Properties from the DB for 'Property' drop-down
            ViewBag.Properties = new SelectList(await propertiesDB.GetAllProperties(), "Id", "Id");
            // Getting the Salespeople from the DB for 'Salesperson' drop-down
            ViewBag.Salespeople = new SelectList(await salespeopleDB.GetSalespeople(), "Id", "Name");

            ViewBag.IsSuccess = isSuccess;

            return View(await dealsDB.GetDeal(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDeal (DealModel dealModel)
        {
            ViewBag.Customers = new SelectList(await customersDB.getCustomers(), "Id", "Name");
            // Getting the Properties from the DB for 'Property' drop-down
            ViewBag.Properties = new SelectList(await propertiesDB.GetAllProperties(), "Id", "Id");
            // Getting the Salespeople from the DB for 'Salesperson' drop-down
            ViewBag.Salespeople = new SelectList(await salespeopleDB.GetSalespeople(), "Id", "Name");

            if (ModelState.IsValid)
            {
                dealsDB.UpdateDeal(dealModel);
                return RedirectToAction(nameof(UpdateDeal), new {dealModel.Id, isSuccess = true});
            }
            ViewBag.IsSuccess = false;

            return View();
        }
    }
}