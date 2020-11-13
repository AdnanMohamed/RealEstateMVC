using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Repository
{
    public class SalespeopleRepository
    {
        private readonly RealEstateContext _RealEstateDB;

        public SalespeopleRepository(RealEstateContext realEstateContext)
        {
            _RealEstateDB = realEstateContext;
        }
        
        public async Task<List<SalespersonModel>> GetSalespeople()
        {
            return await _RealEstateDB.Salespeople.Select(salesperson =>
                    new SalespersonModel()
                    {
                        Id = salesperson.Id,
                        Name = salesperson.Name
                    }).ToListAsync();
        }

        public async Task<SalespersonModel> GetSalesperson(string id)
        {
            Salesperson salesperson = await _RealEstateDB.Salespeople.FindAsync(id);
            return new SalespersonModel()
            {
                Id = salesperson.Id,
                Name = salesperson.Name
            };
        }
    }
}
