using Microsoft.AspNetCore.Mvc;
using TeduCoreApp.Application.Interfaces;
using TeduCoreApp.Application.ViewModels.Product;

namespace TeduCoreApp.Areas.Admin.Views.Controllers
{
	public class ProductController : BaseController
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		public IActionResult Index()
		{
			var products = _productService.GetAll();
			return View(products);
		}

		public IActionResult GetAll(int page = 1, int pageSize = 10)
		{
			var products = _productService.GetAllPaging(null, null, page, pageSize);
			return new JsonResult(products);
		}



	}
}
