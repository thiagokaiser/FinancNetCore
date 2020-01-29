using Api.Models;
using Api.ViewModels;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> UserMgr { get; }
        private SignInManager<AppUser> SignInMgr { get; }

        public AccountController(UserManager<AppUser> userManager,
                                 SignInManager<AppUser> signInManager)
        {
            UserMgr = userManager;
            SignInMgr = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel userForm)
        {
            try
            {
                ViewBag.Message = "User already registered";

                AppUser user = await UserMgr.FindByNameAsync(userForm.UserName);
                if (user == null)
                {
                    user = new AppUser();
                    user.UserName = userForm.UserName;
                    user.Email = userForm.Email;
                    user.FirstName = userForm.FirstName;
                    user.LastName = userForm.LastName;

                    IdentityResult result = await UserMgr.CreateAsync(user, userForm.Password);
                    if (result.Succeeded)
                    {
                        ViewBag.Message = "User was created";
                    }
                    else
                    {                        
                        ViewBag.Message = result.Errors;
                    }
                    
                }
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            var result = await SignInMgr.PasswordSignInAsync(user.UserName,user.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Result = "Usuário e senha incorretos";
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await SignInMgr.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
