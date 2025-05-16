using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Infrastructure.SharedKernel;

namespace TeduCoreApp.Data.Entities
{
	//Bảng quyền
	[Table("Permissions")]
	public class Permission : DomainEntity<int>
	{
		//ID vai trò
		[StringLength(450)]
		[Required]
		public string RoleId { get; set; }

		//ID chức năng
		[StringLength(128)]
		[Required]
		public string FunctionId { get; set; }

		//Có thể tạo
		public bool CanCreate { set; get; }

		//Có thể đọc
		public bool CanRead { set; get; }

		//Có thể cập nhật
		public bool CanUpdate { set; get; }

		//Có thể xóa
		public bool CanDelete { set; get; }

		//Vai trò
		[ForeignKey("RoleId")]
		public virtual AppRole AppRole { get; set; }

		//Chức năng
		[ForeignKey("FunctionId")]
		public virtual Function Function { get; set; }
	}
}
