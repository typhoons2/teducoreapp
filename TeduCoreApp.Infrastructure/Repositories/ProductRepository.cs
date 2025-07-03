using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Data.Entities;
using TeduCoreApp.Data.IRepositories;

namespace TeduCoreApp.Data.EF.Repositories
{
	public class ProductRepository : EFRepository<Product, int>, IProductRepository
	{
		AppDbContext _context;
		public ProductRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}

		public List<Product> GetByAlias(string alias)
		{
			return _context.Products.Where(x => x.SeoAlias == alias).ToList();
		}
	}
} 