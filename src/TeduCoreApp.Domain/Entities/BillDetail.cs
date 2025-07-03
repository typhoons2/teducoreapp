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
	[Table("BillDetails")]
	public class BillDetail : DomainEntity<int>
	{
		public BillDetail() { }

		// Khởi tạo hóa đơn chi tiết với ID
		public BillDetail(int id, int billId, int productId, int quantity, decimal price, int colorId, int sizeId)
		{
			Id = id;
			BillId = billId;
			ProductId = productId;
			Quantity = quantity;
			Price = price;
			ColorId = colorId;
			SizeId = sizeId;
		}

		// Khởi tạo hóa đơn chi tiết với ID
		public BillDetail(int billId, int productId, int quantity, decimal price, int colorId, int sizeId)
		{
			BillId = billId;
			ProductId = productId;
			Quantity = quantity;
			Price = price;
			ColorId = colorId;
			SizeId = sizeId;
		}
		public int BillId { set; get; }//Mã hóa đơn

		public int ProductId { set; get; }//Mã sản phẩm

		public int Quantity { set; get; }//Số lượng

		public decimal Price { set; get; }//Giá

		public int ColorId { get; set; }//Mã màu

		public int SizeId { get; set; }//Mã kích cỡ

		[ForeignKey("BillId")]
		public virtual Bill Bill { set; get; }//Quan hệ với bảng hóa đơn

		[ForeignKey("ProductId")]
		public virtual Product Product { set; get; }//Quan hệ với bảng sản phẩm

		[ForeignKey("ColorId")]
		public virtual Color Color { set; get; }//Quan hệ với bảng màu

		[ForeignKey("SizeId")]
		public virtual Size Size { set; get; }//Quan hệ với bảng kích cỡ
	}
}
