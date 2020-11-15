using RealEstate.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.Repository
{
    public interface ISalespeopleRepository
    {
        Task<List<SalespersonModel>> GetSalespeople();
        Task<SalespersonModel> GetSalesperson(string id);
    }
}