using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Repository
{
    public class DealsRepository
    {
        private readonly RealEstateContext _RealEstateDB;

        public DealsRepository(RealEstateContext realEstateContext)
        {
            _RealEstateDB = realEstateContext;
        }

        public async Task<List<DealModel>> GetDeals()
        {
            return await _RealEstateDB.Deals.Select(deal =>
                    new DealModel()
                    {
                        Id = deal.Id,
                        Customer = _RealEstateDB.Customers.Where(cust => cust.Id == deal.CustomerId).FirstOrDefault().Name,
                        // Seller
                        Commission = deal.Commission,
                        Price = deal.Price,
                        CustomerId = deal.CustomerId,
                        PropertyId = deal.PropertyId,
                        Salesperson = _RealEstateDB.Salespeople.Where(person => person.Id == deal.SalespersonId).FirstOrDefault().Name
                    }).ToListAsync();
        }
    }
}
