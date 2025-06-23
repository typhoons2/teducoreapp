using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Application.ViewModels.Product;

namespace TeduCoreApp.Application.Interfaces
{
	public interface IProductService
	{
		ProductViewModel Add(ProductViewModel productVm);
		void Update(ProductViewModel productVm);
		void Delete(int id);
		List<ProductViewModel> GetAll();
		List<ProductViewModel> GetAll(string keyword);
		ProductViewModel GetById(int id);
		void Save();
	}
} 