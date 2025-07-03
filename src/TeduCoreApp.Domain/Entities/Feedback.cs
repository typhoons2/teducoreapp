using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Domain.Enums;
using TeduCoreApp.Domain.Interfaces;
using TeduCoreApp.Domain.SharedKernel;

namespace TeduCoreApp.Domain.Entities
{
	//Bảng phản hồi
	[Table("Feedbacks")]
	public class Feedback : DomainEntity<int>, ISwitchable, IDateTracking
	{
		//Tên
		[StringLength(250)]
		[Required]
		public string Name { set; get; }

		//Email
		[StringLength(250)]
		public string Email { set; get; }

		//Nội dung
		[StringLength(500)]
		public string Message { set; get; }
		//Trạng thái
		public Status Status { set; get; }

		//Ngày tạo
		public DateTime DateCreated { set; get; }

		//Ngày sửa
		public DateTime DateModified { set; get; }
	}
}
