using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Infrastructure.SharedKernel;

namespace TeduCoreApp.Data.Entities
{
	//Bảng hình ảnh sản phẩm
	[Table("ProductImages")]
	public class ProductImage : DomainEntity<int>
	{
		//ID sản phẩm
		public int ProductId { get; set; }

		[ForeignKey("ProductId")]
		public virtual Product Product { get; set; }

		//Đường dẫn
		[StringLength(250)]
		public string Path { get; set; }

		//Tên
		[StringLength(250)]
		public string Caption { get; set; }
	}
}
