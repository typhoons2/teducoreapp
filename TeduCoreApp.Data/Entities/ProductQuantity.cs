using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Infrastructure.SharedKernel;

namespace TeduCoreApp.Data.Entities
{
	//Bảng số lượng sản phẩm
	[Table("ProductQuantities")]
	public class ProductQuantity : DomainEntity<int>
	{
		//ID sản phẩm
		[Column(Order = 1)]
		public int ProductId { get; set; }

		//ID kích cỡ
		[Column(Order = 2)]
		public int SizeId { get; set; }

		//ID màu sắc
		[Column(Order = 3)]
		public int ColorId { get; set; }

		//Số lượng
		public int Quantity { get; set; }
	
		//Sản phẩm
		[ForeignKey("ProductId")]
		public virtual Product Product { get; set; }

		//Kích cỡ
		[ForeignKey("SizeId")]
		public virtual Size Size { get; set; }

		//Màu sắc
		[ForeignKey("ColorId")]
		public virtual Color Color { get; set; }
	}
}
