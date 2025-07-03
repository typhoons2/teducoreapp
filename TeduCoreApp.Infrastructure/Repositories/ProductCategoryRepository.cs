using TeduCoreApp.Domain.Entities;
using TeduCoreApp.Domain.Repositories;
using TeduCoreApp.Infrastructure.Persistence.DbContext;
using TeduCoreApp.Infrastructure.Repositories;

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
