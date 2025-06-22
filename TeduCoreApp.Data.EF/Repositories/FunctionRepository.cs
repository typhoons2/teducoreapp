using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Data.Entities;
using TeduCoreApp.Data.IRepositories;

namespace TeduCoreApp.Data.EF.Repositories
{
	public class FunctionRepository : EFRepository<Function, string>, IFunctionRepository
	{
		public FunctionRepository(AppDbContext context) : base(context)
		{
		}
	}
}
