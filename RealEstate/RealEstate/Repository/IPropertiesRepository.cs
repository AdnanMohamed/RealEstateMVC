using RealEstate.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.Repository
{
    public interface IPropertiesRepository
    {
        Task<string> AddNewProperty(PropertyModel propertyModel);
        Task<bool> DeleteProperty(string id);
        Task<List<PropertyModel>> GetAllProperties();
        Task<PropertyModel> GetProperty(string id);
        void UpdateProperty(PropertyModel propertyModel);
    }
}