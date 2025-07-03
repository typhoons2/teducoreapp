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
	//Bảng footer
	[Table("Footers")]
	public class Footer : DomainEntity<string>
	{
		//Nội dung
		[Required]
		public string Content { set; get; }
	}
}
