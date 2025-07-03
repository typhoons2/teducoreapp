using System.Collections.Generic;
using TeduCoreApp.Domain.Entities;

namespace TeduCoreApp.Domain.Repositories
{
	public interface IProductRepository : IRepository<Product, int>
	{
		List<Product> GetByAlias(string alias);
	}
} 