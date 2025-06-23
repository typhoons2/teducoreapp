using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TeduCoreApp.Extensions;
using System.Security.Claims;
using TeduCoreApp.Areas.Admin.Views.Controllers;

namespace TeduCoreApp.Areas.Admin.Controllers
{
	public class HomeController : BaseController
	{
		public IActionResult Index()
		{
			var email = User.GetSpecificClaim(ClaimTypes.Email);
			return View();
		}
	}
}
