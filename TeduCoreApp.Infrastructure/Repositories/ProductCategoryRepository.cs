using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Data.Entities;
using TeduCoreApp.Data.IRepositories;

namespace TeduCoreApp.Data.EF.Repositories
{
	public class ProductCategoryRepository : EFRepository<ProductCategory, int>, IProductCategoryRepository
	{
		AppDbContext _context;
		public ProductCategoryRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}

		public List<ProductCategory> GetByAlias(string alias)
		{
			return _context.ProductCategories.Where(x=>x.SeoAlias==alias).ToList();
		}
	}
}
