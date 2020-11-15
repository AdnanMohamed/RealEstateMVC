using Microsoft.AspNetCore.Identity;
using RealEstate.Models;
using System.Threading.Tasks;

namespace RealEstate.Repository
{
    public interface IAccountsRepository
    {
        Task<IdentityResult> CreateUserAsync(UserModel userModel);
        Task<SignInResult> LoginAsync(SigninModel signinModel);
        Task SignoutAsync();
    }
}