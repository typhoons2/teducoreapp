using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Application.ViewModels.Product;
using TeduCoreApp.Utilities.Dtos;

namespace TeduCoreApp.Application.Interfaces
{
	public interface IProductService
	{
		ProductViewModel Add(ProductViewModel productVm);
		
		PagedResult<ProductViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize);
		
		void Update(ProductViewModel productVm);
		void Delete(int id);
		List<ProductViewModel> GetAll();
		List<ProductViewModel> GetAll(string keyword);
		ProductViewModel GetById(int id);
		void Save();
	}
} 