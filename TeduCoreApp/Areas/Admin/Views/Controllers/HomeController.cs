using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TeduCoreApp.Extensions;
using System.Security.Claims;

namespace TeduCoreApp.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			var email = User.GetSpecificClaim(ClaimTypes.Email);
			return View();
		}
	}
}
