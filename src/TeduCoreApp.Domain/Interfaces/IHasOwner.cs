using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduCoreApp.Domain.Interfaces
{
	public interface IHasOwner<T>
	{
		T OwnerId { get; set; }
	}
}
