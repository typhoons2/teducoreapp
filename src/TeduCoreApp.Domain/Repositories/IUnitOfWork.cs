using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduCoreApp.Domain.Repositories
{
	public interface IUnitOfWork : IDisposable
	{
		/// <summary>
		/// call save change from db context
		/// </summary>
		void Commit();
	}
}
