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

        public async Task<DealModel> GetDeal(string id)
        {
            Deal deal = _RealEstateDB.Deals.Find(id);
            return new DealModel()
            {
                Id = deal.Id,
                CustomerId = deal.CustomerId,
                SalespersonId = deal.SalespersonId,
                PropertyId = deal.PropertyId,
                Customer = _RealEstateDB.Customers.Find(deal.CustomerId).Name,
                Salesperson = _RealEstateDB.Salespeople.Find(deal.SalespersonId).Name,
                Commission = deal.Commission,
                Price = deal.Price,
                Date = deal.CreatedOn.Date.ToString()
            };
        }
        public async Task<List<DealModel>> GetDeals()
        {
            return await _RealEstateDB.Deals.Select(deal =>
                    new DealModel()
                    {
                        Id = deal.Id,
                        Customer = _RealEstateDB.Customers.Where(cust => cust.Id == deal.CustomerId).FirstOrDefault().Name,
                        //Seller = _RealEstateDB.Customers.Find(_RealEstateDB.Properties.Find(deal.PropertyId).CustomerId).Name,
                        Commission = deal.Commission,
                        Price = deal.Price,
                        // buyer
                        CustomerId = deal.CustomerId,
                        PropertyId = deal.PropertyId,
                        SalespersonId = deal.SalespersonId,
                        Date = deal.CreatedOn.Date.ToString(),
                        Salesperson = _RealEstateDB.Salespeople.Where(person => person.Id == deal.SalespersonId).FirstOrDefault().Name
                        
                    }).ToListAsync();
        }

        public async Task<string> AddNewDeal(DealModel dealModel)
        {
            Deal deal = new Deal()
            {
                Id = dealModel.Id,
                CustomerId = dealModel.CustomerId,
                PropertyId = dealModel.PropertyId,
                SalespersonId = dealModel.SalespersonId,
                Commission = dealModel.Commission,
                Price = dealModel.Price,
                CreatedOn = DateTime.Now
            };
            await _RealEstateDB.Deals.AddAsync(deal);
            Customer cust = await _RealEstateDB.Customers.FindAsync(deal.CustomerId);
            cust.Deals.Add(deal);
            Property property = await _RealEstateDB.Properties.FindAsync(deal.PropertyId);
            property.Deals.Add(deal);
            property.CustomerId = deal.CustomerId;
            //property.CustomerName = cust.Name;
            await _RealEstateDB.SaveChangesAsync();
            return dealModel.Id;
        }

        public async Task<bool> DeleteDeal(string id)
        {
            Deal deal = await _RealEstateDB.Deals.FindAsync(id);
            if (deal != null)
            {
                _RealEstateDB.Deals.Remove(deal);
                await _RealEstateDB.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public void UpdateDeal(DealModel dealModel)
        {
            Deal deal = new Deal()
            {
                Id = dealModel.Id,
                CustomerId = dealModel.CustomerId,
                PropertyId = dealModel.PropertyId,
                SalespersonId = dealModel.SalespersonId,
                Commission = dealModel.Commission,
                Price = dealModel.Price,
                CreatedOn = DateTime.Now
            };
            _RealEstateDB.Deals.Update(deal);
            _RealEstateDB.SaveChanges();
        }
    }
}
