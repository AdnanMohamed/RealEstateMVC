using RealEstate.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.Repository
{
    public interface IDealsRepository
    {
        Task<string> AddNewDeal(DealModel dealModel);
        Task<bool> DeleteDeal(string id);
        Task<DealModel> GetDeal(string id);
        Task<List<DealModel>> GetDeals();
        void UpdateDeal(DealModel dealModel);
    }
}