using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Repository
{
    public class PropertiesRepository
    {
        private readonly RealEstateContext _context = null;

        public PropertiesRepository(RealEstateContext context)
        {
            _context = context;
        }

        public async Task<string> AddNewProperty(PropertyModel propertyModel)
        {
            Property property = new Property
            {
                Id = propertyModel.Id,
                CustomerId = propertyModel.CustomerId,
                PropertyType = propertyModel.PropertyType,
                LocationURL = propertyModel.LocationURL,
                Location = propertyModel.Location,
                //CustomerName = _context.Customers.Find(propertyModel.CustomerId).Name
            };
            await _context.Properties.AddAsync(property);
            await _context.SaveChangesAsync();
            return property.Id;
        }

        public async Task<List<PropertyModel>> GetAllProperties()
        {
            var properties = new List<PropertyModel>();
            var allProperties = await _context.Properties.ToListAsync();
            if (allProperties?.Any() == true)
            {
                foreach (var property in allProperties)
                {
                    properties.Add(new PropertyModel()
                    {
                        CustomerId = property.CustomerId,
                        Id = property.Id,
                        Location = property.Location,
                        LocationURL = property.LocationURL,
                        PropertyType = property.PropertyType,
                        CustomerName = _context.Customers.Find(property.CustomerId).Name
                    });
                }
            }
            return properties;            
        }

        public async Task<PropertyModel> GetProperty(string id)
        {
            var p = await _context.Properties.FindAsync(id);
            return new PropertyModel()
            {
                Id = p.Id,
                CustomerId = p.CustomerId,
                CustomerName = _context.Customers.Find(p.CustomerId).Name,
                PropertyType = p.PropertyType,
                Location = p.Location,
                LocationURL = p.LocationURL
            };
        }

        public async Task<bool> DeleteProperty(string id)
        {
            Property p = _context.Properties.Find(id);
            if (p != null)
            {
                _context.Properties.Remove(p);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public void UpdateProperty(PropertyModel propertyModel)
        {
            Property p = new Property()
            {
                Id = propertyModel.Id,
                CustomerId = propertyModel.CustomerId,
                //CustomerName = propertyModel.CustomerName,
                PropertyType = propertyModel.PropertyType,
                Location = propertyModel.Location,
                LocationURL = propertyModel.LocationURL
            };
            _context.Properties.Update(p);
            _context.SaveChanges();
        }
    }
}
