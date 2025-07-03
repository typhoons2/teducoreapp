using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Domain.Entities;

namespace TeduCoreApp.Domain.Repositories
{
	public interface IProductCategoryRepository : IRepository<ProductCategory,int>
	{
		List<ProductCategory> GetByAlias(string alias);

	}
}
 