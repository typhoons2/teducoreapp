using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Data.Enums;
using TeduCoreApp.Data.Interfaces;
using TeduCoreApp.Infrastructure.SharedKernel;

namespace TeduCoreApp.Data.Entities
{
	//Bảng trang
	[Table("Pages")]
	public class Page : DomainEntity<int>, ISwitchable
	{
		//Tên
		[Required]	
		[MaxLength(256)]
		public string Name { set; get; }

		//Alias
		[MaxLength(256)]
		[Required]
		public string Alias { set; get; }

		//Nội dung
		public string Content { set; get; }

		//Trạng thái
		public Status Status { set; get; }
	}
}
