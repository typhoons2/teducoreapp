using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Domain.Enums;

namespace TeduCoreApp.Domain.Interfaces
{
	public interface ISwitchable
	{
		Status Status { get; set; }	
	}
}
