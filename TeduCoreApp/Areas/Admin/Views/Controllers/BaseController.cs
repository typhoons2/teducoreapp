using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TeduCoreApp.Areas.Admin.Views.Controllers
{
	[Area("Admin")]
	[Authorize]
	public abstract class BaseController : Controller
	{
		
	}
}
