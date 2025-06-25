using Microsoft.AspNetCore.Mvc;
using TeduCoreApp.Application.Implementations;
using TeduCoreApp.Application.Interfaces;
using TeduCoreApp.Application.ViewModels.Product;

namespace TeduCoreApp.Areas.Admin.Views.Controllers
{
	public class ProductCategoryController : BaseController
	{
		private readonly IProductCategoryService _productCategoryService;
		public ProductCategoryController(IProductCategoryService productCategoryService)
		{
			_productCategoryService = productCategoryService;
		}
		public IActionResult Index()
		{
			return View();
		}

		

		#region Get Data API
		[HttpGet]
		public IActionResult GetAll()
		{
			var model = _productCategoryService.GetAll();
			return new OkObjectResult(model);
		}

		[HttpPost]
		public IActionResult UpdateParentId(int sourceId, int targetId, List<ItemDto> items)
		{
			if (!ModelState.IsValid)
			{
				return new BadRequestObjectResult(ModelState);
			}
			else
			{
				if (sourceId == targetId)
				{
					return new BadRequestResult();
				}
				else
				{
					var dict = items?.ToDictionary(x => x.key, x => x.value) ?? new Dictionary<int, int>();
					_productCategoryService.UpdateParentId(sourceId, targetId, dict);
					_productCategoryService.Save();
					return new OkResult();
				}
			}
		}

		[HttpPost]
		public IActionResult ReOrder(int sourceId, int targetId)
		{
			if (!ModelState.IsValid)
			{
				return new BadRequestObjectResult(ModelState);
			}
			else
			{
				if (sourceId == targetId)
				{
					return new BadRequestResult();
				}
				else
				{
					_productCategoryService.ReOrder(sourceId, targetId);
					_productCategoryService.Save();
					return new OkResult();
				}
			}
		}

		#endregion
	}
}
