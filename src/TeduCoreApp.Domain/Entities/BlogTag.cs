using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Domain.SharedKernel;

namespace TeduCoreApp.Domain.Entities
{
	// Định nghĩa lớp BlogTag kế thừa từ DomainEntity<int>
	[Table("BlogTags")]
	public class BlogTag : DomainEntity<int>
	{
		public int BlogId { set; get; } //Mã bài viết

		public string TagId { set; get; } //Mã tag	

		// Khởi tạo quan hệ với bài viết
		[ForeignKey("BlogId")]
		public virtual Blog Blog { set; get; }

		// Khởi tạo quan hệ với tag
		[ForeignKey("TagId")]
		public virtual Tag Tag { set; get; }
	}
}
