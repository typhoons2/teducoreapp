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
	// Định nghĩa lớp Color kế thừa từ DomainEntity<int>
	[Table("Colors")]
	public class Color : DomainEntity<int>
	{

		// Khởi tạo mã màu	
		[StringLength(250)]
		public string Name
		{
			get; set;
		}

		// Khởi tạo mã màu	
		[StringLength(250)]
		public string Code { get; set; }
	}
}
