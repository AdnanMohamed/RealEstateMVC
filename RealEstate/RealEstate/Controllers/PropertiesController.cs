using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RealEstate.Data;
using RealEstate.Models;
using RealEstate.Repository;

namespace RealEstate.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly PropertiesRepository propertiesDB;
        private readonly CustomersRepository customersDB;
        public PropertiesController(PropertiesRepository propertiesRepository, CustomersRepository customersRepository)
        {
            propertiesDB = propertiesRepository;
            customersDB = customersRepository;
        }
        public async Task<IActionResult> GetAllProperties()
        {
            var properties = await propertiesDB.GetAllProperties();
            return View(properties);
        }

        public async Task<IActionResult> AddNewProperty(bool isSuccess = false, string PropertyId = "")
        {
            // Creating the list of property types for the drop-down.
            ViewBag.PropertyTypes = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "Landscape", Value = "Landscape" },
                new SelectListItem(){Text = "House", Value = "House"},
                new SelectListItem(){Text = "Flat", Value = "Flat"}
            };

            // Getting the Customers from the DB for 'owner' drop-down
            ViewBag.Customers = new SelectList(await customersDB.getCustomers(), "Id", "Name");

            ViewBag.isSuccess = isSuccess;
            ViewBag.PropertyId = PropertyId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProperty(PropertyModel propertyModel)
        {
            // Getting the Customers from the DB for 'owner' drop-down
            ViewBag.Customers = new SelectList(await customersDB.getCustomers(), "Id", "Name");

            // Creating the list of property types for the drop-down.
            ViewBag.PropertyTypes = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "Landscape", Value = "Landscape" },
                new SelectListItem(){Text = "House", Value = "House"},
                new SelectListItem(){Text = "Flat", Value = "Flat"}
            };

            if (ModelState.IsValid)
            {
                string id = await propertiesDB.AddNewProperty(propertyModel);   // saving the property id.
                return RedirectToAction(nameof(AddNewProperty), new { isSuccess = true, PropertyId = id });
            }


            return RedirectToAction();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProperty(string id)
        {
            await propertiesDB.DeleteProperty(id);
            return RedirectToAction(nameof(GetAllProperties));
        }

        public async Task<ViewResult> UpdateProperty(string id, bool isSuccess = false)
        {
            ViewBag.IsSuccess = isSuccess;
            PropertyModel propModel = await propertiesDB.GetProperty(id);

            // Getting the Customers from the DB for 'owner' drop-down
            ViewBag.Customers = new SelectList(await customersDB.getCustomers(), "Id", "Name");

            // Creating the list of property types for the drop-down.
            ViewBag.PropertyTypes = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "Landscape", Value = "Landscape" },
                new SelectListItem(){Text = "House", Value = "House"},
                new SelectListItem(){Text = "Flat", Value = "Flat"}
            };
            return View(propModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProperty(PropertyModel propertyModel)
        {
            // Getting the Customers from the DB for 'owner' drop-down
            ViewBag.Customers = new SelectList(await customersDB.getCustomers(), "Id", "Name");

            // Creating the list of property types for the drop-down.
            ViewBag.PropertyTypes = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "Landscape", Value = "Landscape" },
                new SelectListItem(){Text = "House", Value = "House"},
                new SelectListItem(){Text = "Flat", Value = "Flat"}
            };

            if (ModelState.IsValid)
            {
                propertiesDB.UpdateProperty(propertyModel);
                return RedirectToAction(nameof(UpdateProperty), new { isSuccess = true });
            }
            ViewBag.IsSuccess = false;
            return View(propertyModel);
        }
    }
}