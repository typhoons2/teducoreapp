using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Application.ViewModels.System;

namespace TeduCoreApp.Application.Interfaces
{
	public interface IFunctionService : IDisposable
	{
		Task<List<FunctionViewModel>> GetAllAsync();
		Task<List<FunctionViewModel>> GetAllByPermissionAsync(Guid userId);
	}
}
