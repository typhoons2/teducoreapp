using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Infrastructure.SharedKernel;

namespace TeduCoreApp.Data.Entities
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
