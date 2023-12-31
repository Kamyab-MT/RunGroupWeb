﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using RunGroupsWeb.Data;
using RunGroupsWeb.Models;
using RunGroupWeb.Data;
using RunGroupWeb.ViewModels;

namespace RunGroupWeb.Controllers
{
    public class AccountController : Controller
    {

        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly ApplicationDbContext _dbContext;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
        }


        public IActionResult Login()
        {
            var response = new LoginViewModel(); // If the user accidently press the reload this would hold the values for him/her
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if(!ModelState.IsValid) return View(loginViewModel);

            AppUser user = await _userManager.FindByEmailAsync(loginViewModel.Email); // first we need to check that the user actually exist

            if(user != null)
            {
                //User has been found

                bool passwordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);

                if (passwordCheck)
                {
                    //Password is correct

                    var result = _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                    if (result.Result == Microsoft.AspNetCore.Identity.SignInResult.Success)
                        return RedirectToAction("Index", "Race");

                    TempData["Error"] = "Failed to login, Please try Again";
                    return View(loginViewModel);
                }

                TempData["Error"] = "Wrong password, Please try again";
                return View(loginViewModel);
            }

            TempData["Error"] = "Wrong credintials, Please try again";
            return View(loginViewModel);
        }

        public IActionResult Register()
        {
            var registerViewModel = new RegisterViewModel();
            return View(registerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) return View(registerViewModel);

            var userCheck = await _userManager.FindByEmailAsync(registerViewModel.Email);

            if (userCheck != null)
            {
                TempData["Error"] = "Email is already in use";
                return View(registerViewModel);
            }

            AppUser user = new AppUser()
            {
                Email = registerViewModel.Email,
                UserName = registerViewModel.Email
            };

            var response = await _userManager.CreateAsync(user, registerViewModel.Password);

            if (response.Succeeded)
                await _userManager.AddToRoleAsync(user, UserRole.User);
            else
                return View(registerViewModel);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
