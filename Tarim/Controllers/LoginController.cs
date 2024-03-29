﻿using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tarim.Models;

namespace Tarim.Controllers
{
	public class LoginController : Controller
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;

		public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}
		[AllowAnonymous]
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
        {
			IdentityUser ıdentityUser = new IdentityUser();

            if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(loginViewModel.username, loginViewModel.password, false, false);
				if(result.Succeeded)
				{
					return RedirectToAction("Index", "Dashboard");
				}
				else
				{
					return RedirectToAction("Index");
				}
			}
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
		public IActionResult SingUp()
		{

			return View();
		}
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SingUp(RegisterViewModel registerViewModel)
        {
			IdentityUser ıdentityUser = new IdentityUser()
			{
				//Id="1",
				UserName = registerViewModel.userName,
				Email = registerViewModel.mail
			};
			if (registerViewModel.password == registerViewModel.passwordConfirm)
			{
				var result = await _userManager.CreateAsync(ıdentityUser, registerViewModel.password);
				if (result.Succeeded)
				{
					return RedirectToAction("Index");
				}
				else
				{
					foreach (var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}
				}
			}
            return View(registerViewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
