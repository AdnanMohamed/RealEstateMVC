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
    [Route("[controller]/[action]")]
    public class PropertiesController : Controller
    {
        private readonly IPropertiesRepository _propertiesRepository;
        private readonly ICustomersRepository _customersRepository;
        public PropertiesController(IPropertiesRepository propertiesRepository, ICustomersRepository customersRepository)
        {
            _propertiesRepository = propertiesRepository;
            _customersRepository = customersRepository;
        }
        public async Task<IActionResult> GetAllProperties()
        {
            var properties = await _propertiesRepository.GetAllProperties();
            return View(properties);
        }

        public IActionResult AddNewProperty(bool isSuccess = false, string PropertyId = "")
        {
            // Creating the list of property types for the drop-down.
            ViewBag.PropertyTypes = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "Landscape", Value = "Landscape" },
                new SelectListItem(){Text = "House", Value = "House"},
                new SelectListItem(){Text = "Flat", Value = "Flat"}
            };

            ViewBag.isSuccess = isSuccess;
            ViewBag.PropertyId = PropertyId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProperty(PropertyModel propertyModel)
        {
            // Creating the list of property types for the drop-down.
            ViewBag.PropertyTypes = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "Landscape", Value = "Landscape" },
                new SelectListItem(){Text = "House", Value = "House"},
                new SelectListItem(){Text = "Flat", Value = "Flat"}
            };

            if (ModelState.IsValid)
            {
                string id = await _propertiesRepository.AddNewProperty(propertyModel);   // saving the property id.
                return RedirectToAction(nameof(AddNewProperty), new { isSuccess = true, PropertyId = id });
            }

            return RedirectToAction();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProperty(string id)
        {
            await _propertiesRepository.DeleteProperty(id);
            return RedirectToAction(nameof(GetAllProperties));
        }

        public async Task<ViewResult> UpdateProperty(string id, bool isSuccess = false)
        {
            ViewBag.IsSuccess = isSuccess;
            PropertyModel propModel = await _propertiesRepository.GetProperty(id);

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
        public IActionResult UpdateProperty(PropertyModel propertyModel)
        {

            // Creating the list of property types for the drop-down.
            ViewBag.PropertyTypes = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "Landscape", Value = "Landscape" },
                new SelectListItem(){Text = "House", Value = "House"},
                new SelectListItem(){Text = "Flat", Value = "Flat"}
            };

            if (ModelState.IsValid)
            {
                _propertiesRepository.UpdateProperty(propertyModel);
                return RedirectToAction(nameof(UpdateProperty), new {id = propertyModel.Id, isSuccess = true });
            } 
            ViewBag.IsSuccess = false;
            return View(propertyModel);
        }
    }
}