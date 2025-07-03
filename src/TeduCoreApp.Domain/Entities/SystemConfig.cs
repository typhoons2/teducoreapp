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
	//Bảng cấu hình hệ thống
	[Table("SystemConfigs")]
	public class SystemConfig : DomainEntity<string>, ISwitchable
	{
		//Tên
		[Required]
		[StringLength(128)]
		public string Name { get; set; }

		//Giá trị 1
		public string Value1 { get; set; }

		//Giá trị 2
		public int? Value2 { get; set; }

		//Giá trị 3
		public bool? Value3 { get; set; }

		//Giá trị 4
		public DateTime? Value4 { get; set; }

		//Giá trị 5
		public decimal? Value5 { get; set; }

		//Trạng thái	
		public Status Status { get; set; }
	}
}
