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
	//Bảng ngôn ngữ
	[Table("Languages")]
	public class Language : DomainEntity<string>, ISwitchable
	{
		//Tên
		[Required]
		[StringLength(128)]
		public string Name { get; set; }

		//Mã
		public bool IsDefault { get; set; }

		//Tài nguyên
		public string Resources { get; set; }

		//Trạng thái
		public Status Status { get; set; }
	}
}
