﻿using System.Threading.Tasks;
using MyNewApp.Web.Models;
using IntelligentPlant.IndustrialAppStore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace MyNewApp.Web.Controllers {
    public class AccountController : Controller {

        [HttpGet]
        public IActionResult Login(string returnUrl = "/") {
            var viewModel = new LoginViewModel() {
                IsPersistent = false,
                RedirectUrl = returnUrl
            };
            return View(viewModel);
        }


        [HttpPost]
        [ActionName(nameof(Login))]
        [ValidateAntiForgeryToken]
        public IActionResult LoginPost(LoginViewModel viewModel) {
            return Challenge(new AuthenticationProperties() {
                IsPersistent = viewModel.IsPersistent,
                RedirectUri = string.IsNullOrWhiteSpace(viewModel.RedirectUrl) 
                    ? "/" 
                    : viewModel.RedirectUrl
            }, IndustrialAppStoreAuthenticationDefaults.AuthenticationScheme);
        }


        [HttpGet]
        public async Task<IActionResult> Logout() {
            await Request.HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
