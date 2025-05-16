using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Data.Enums;
using TeduCoreApp.Infrastructure.SharedKernel;

namespace TeduCoreApp.Data.Entities
{
	//Bảng liên hệ
	[Table("ContactDetails")]
	public class Contact : DomainEntity<string>
	{
		//Tên liên hệ
		[StringLength(250)]
		[Required]
		public string Name { set; get; }

		//Số điện thoại
		[StringLength(50)]
		public string Phone { set; get; }

		//Email
		[StringLength(250)]
		public string Email { set; get; }

		//Website
		[StringLength(250)]
		public string Website { set; get; }

		//Địa chỉ
		[StringLength(250)]
		public string Address { set; get; }

		//Nội dung khác
		public string Other { set; get; }

		//Vĩ độ
		public double? Lat { set; get; }

		//Kinh độ
		public double? Lng { set; get; }

		//Trạng thái
		public Status Status { set; get; }
	}
}
