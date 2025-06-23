using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using TeduCoreApp.Data.Entities;

namespace TeduCoreApp.Areas.Admin.Views.Controllers
{
	
	public class AccountController : BaseController
	{
		private readonly SignInManager<AppUser> _signInManager;
		public AccountController(SignInManager<AppUser> signInManager)
		{
			_signInManager = signInManager;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Login", new { area = "Admin" });
		}
	}
}
