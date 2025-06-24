using Microsoft.AspNetCore.Mvc;
using TeduCoreApp.Application.Interfaces;
using TeduCoreApp.Application.ViewModels.Product;

namespace TeduCoreApp.Areas.Admin.Views.Controllers
{
	public class ProductController : BaseController
	{
		private readonly IProductService _productService;
		private readonly IProductCategoryService _productCategoryService;

		public ProductController(IProductService productService, IProductCategoryService productCategoryService)
		{
			_productService = productService;
			_productCategoryService = productCategoryService;
		}
		public IActionResult Index()
		{
			var products = _productService.GetAll();
			return View(products);
		}


		public IActionResult GetAllCategories() { 
			var model = _productCategoryService.GetAll();
			return new JsonResult(model);
		}

		public IActionResult GetAll(int? categoryId, string keyword, int page = 1, int pageSize = 10)
		{
			var products = _productService.GetAllPaging(categoryId, keyword, page, pageSize);
			return new JsonResult(products);
		}



	}
}
