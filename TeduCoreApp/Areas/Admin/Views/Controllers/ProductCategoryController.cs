using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
using TeduCoreApp.Application.Implementations;
using TeduCoreApp.Application.Interfaces;
using TeduCoreApp.Application.ViewModels.Product;
using TeduCoreApp.Utilities.Helpers;

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

		#region CRUD

		[HttpGet]
		public IActionResult GetById(int id)
		{
			var model = _productCategoryService.GetById(id);
			return new OkObjectResult(model);
		}

		[HttpPost]
		public IActionResult SaveEntity(ProductCategoryViewModel productCategoryVm)
		{
			if (!ModelState.IsValid)
			{
				IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
				return new BadRequestObjectResult(allErrors);
			}

			productCategoryVm.SeoAlias = TextHelper.ToUnsignString(productCategoryVm.Name);

			if (productCategoryVm.Id == 0)
			{
				_productCategoryService.Add(productCategoryVm);
			}
			else
			{
				_productCategoryService.Update(productCategoryVm);
			}

			_productCategoryService.Save();
			return new OkObjectResult(productCategoryVm);
		}

		[HttpPost]
		public IActionResult Delete(int id)
		{
			if (id == 0)
			{
				return new BadRequestResult();
			}

			_productCategoryService.Delete(id);
			_productCategoryService.Save();
			return new OkObjectResult(id);
		}

		#endregion
	}

	// Dto hỗ trợ cập nhật ParentId
	public class ItemDto
	{
		public int key { get; set; }
		public int value { get; set; }
	}
}
