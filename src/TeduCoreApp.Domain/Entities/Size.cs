using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Domain.SharedKernel;

namespace TeduCoreApp.Domain.Entities
{
	[Table("Sizes")]
	public class Size : DomainEntity<int>
	{
		//Tên
		[StringLength(250)]
		public string Name
		{
			get; set;
		}
	}
}
