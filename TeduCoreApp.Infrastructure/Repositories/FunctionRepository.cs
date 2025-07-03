using TeduCoreApp.Domain.Entities;
using TeduCoreApp.Domain.Repositories;
using TeduCoreApp.Infrastructure.Persistence.DbContext;
using TeduCoreApp.Infrastructure.Repositories;

namespace TeduCoreApp.Data.EF.Repositories
{
	public class FunctionRepository : EFRepository<Function, string>, IFunctionRepository
	{
		public FunctionRepository(AppDbContext context) : base(context)
		{
		}
	}
}
