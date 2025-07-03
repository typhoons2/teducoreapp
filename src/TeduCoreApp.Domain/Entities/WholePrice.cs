using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Domain.SharedKernel;

namespace TeduCoreApp.Domain.Entities
{
	//Bảng giá sản phẩm
	[Table("WholePrices")]
	public class WholePrice : DomainEntity<int>
	{
		//ID sản phẩm
		public int ProductId { get; set; }

		//Số lượng từ
		public int FromQuantity { get; set; }

		//Số lượng đến
		public int ToQuantity { get; set; }

		//Giá
		public decimal Price { get; set; }

		//Sản phẩm	
		[ForeignKey("ProductId")]
		public virtual Product Product { get; set; }
	}
}
