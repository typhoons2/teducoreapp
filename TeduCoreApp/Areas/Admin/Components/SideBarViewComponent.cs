using Microsoft.AspNetCore.Mvc;
using TeduCoreApp.Application.Interfaces;
using TeduCoreApp.Application.ViewModels.System;
using TeduCoreApp.Utilities.Constants;
using System.Security.Claims;
using TeduCoreApp.Extensions;


namespace TeduCoreApp.Areas.Admin.Components
{
	public class SideBarViewComponent : ViewComponent
	{
		private readonly IFunctionService _functionService;
		public SideBarViewComponent(IFunctionService functionService)
		{
			_functionService = functionService;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var roles = ((ClaimsPrincipal)User).GetSpecificClaim(ClaimTypes.Role);
			List<FunctionViewModel> functions = new List<FunctionViewModel>();
			if (roles.Split(";").Contains("Admin"))
			{
				functions = await _functionService.GetAllAsync();
			}
			else
			{
				//TODO: Get by permission
				functions = await _functionService.GetAllAsync();
			}
			return View(functions);
		}
	}
}

