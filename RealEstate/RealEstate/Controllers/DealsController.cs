using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Repository;

namespace RealEstate.Controllers
{
    public class DealsController : Controller
    {
        private readonly PropertiesRepository propertiesDB;
        private readonly CustomersRepository customersDB;
        private readonly SalespeopleRepository salespeopleRepository;
        public async Task<List<IActionResult>> GetAllDeals()
        {
            return null;
        }
    }
}