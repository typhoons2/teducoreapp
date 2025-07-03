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
	[Table("Slides")]
	public class Slide : DomainEntity<int>
	{
		//Tên
		[StringLength(250)]
		[Required]
		public string Name { set; get; }

		//Mô tả
		[StringLength(250)]
		public string Description { set; get; }

		//Hình ảnh
		[StringLength(250)]
		[Required]
		public string Image { set; get; }

		//URL
		[StringLength(250)]
		public string Url { set; get; }

		//Thứ tự
		public int? DisplayOrder { set; get; }

		//Trạng thái	
		public bool Status { set; get; }

		//Nội dung
		public string Content { set; get; }

		//Alias
		[StringLength(25)]
		[Required]
		public string GroupAlias { get; set; }
	}
}
