using RealEstate.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.Repository
{
    public interface ICustomersRepository
    {
        Task<string> AddNewCustomer(CustomerModel model);
        Task<bool> DeleteCustomer(string id);
        Task<CustomerModel> GetCustomer(string id);
        Task<List<CustomerModel>> getCustomers();
        void UpdateCustomer(CustomerModel customerModel);
    }
}