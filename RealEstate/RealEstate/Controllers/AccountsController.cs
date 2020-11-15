using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Models;
using RealEstate.Repository;

namespace RealEstate.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAccountsRepository _accountsRepository;

        public AccountsController(IAccountsRepository accountsRepository)
        {
            _accountsRepository = accountsRepository;
        }

        [Route("signup")]
        public IActionResult Signup()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> Signup(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountsRepository.CreateUserAsync(userModel);
                if (!result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                    return View();
                }
                ModelState.Clear();
            }
            return View();
        }

        [Route("signin")]
        public IActionResult Signin()
        {
            return View();
        }

        [Route("signin")]
        [HttpPost]
        public async Task<IActionResult> Signin(SigninModel signinModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountsRepository.LoginAsync(signinModel);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Invalid Credentials");
                    return View();
                }
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return LocalRedirect(returnUrl);
                }
                ModelState.Clear();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [Route("signout")]
        public async Task<IActionResult> Signout()
        {
            await _accountsRepository.SignoutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}