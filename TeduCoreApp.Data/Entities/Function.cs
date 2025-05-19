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
	//Bảng chức năng	
	[Table("Functions")]
	public class Function : DomainEntity<string>, ISwitchable, ISortable
	{
		public Function()
		{

		}
		//Khởi tạo chức năng
		public Function(string name, string url, string parentId, string iconCss, int sortOrder)
		{
			this.Name = name;
			this.URL = url;
			this.ParentId = parentId;
			this.IconCss = iconCss;
			this.SortOrder = sortOrder;
			this.Status = Status.Active;
		}
		//Tên chức năng
		[Required]
		[StringLength(128)]
		public string Name { set; get; }

		//URL
		[Required]
		[StringLength(250)]
		public string URL { set; get; }

		//ID cha
		[StringLength(128)]
		public string? ParentId { set; get; }
	
		//Icon CSS
		[StringLength(128)]
		public string IconCss { get; set; }

		//Thứ tự
		public int SortOrder { set; get; }

		//Trạng thái
		public Status Status { set; get; }
	}
}
