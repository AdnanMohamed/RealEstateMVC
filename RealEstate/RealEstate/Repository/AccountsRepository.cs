using Microsoft.AspNetCore.Identity;
using RealEstate.Data;
using RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Repository
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountsRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> CreateUserAsync(UserModel userModel)
        {
            var user = new ApplicationUser()
            {
                Email = userModel.Email,
                UserName = userModel.Email,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName
            };

            return await _userManager.CreateAsync(user, userModel.Password);
        }

        public async Task<SignInResult> LoginAsync(SigninModel signinModel)
        {
            return await _signInManager.PasswordSignInAsync(signinModel.Email, signinModel.Password, signinModel.RememberMe, false);           
        }
        public async Task SignoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }

}
