using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Domain.Enums;
using TeduCoreApp.Domain.Interfaces;
using TeduCoreApp.Domain.SharedKernel;


/*
Product
	Id
	Name
	Alias
	Seo
	CategoryId
	CreatedDate,
	Status,
	Image,
	Price
	PromotionPrice,
	Quantity,
	Description
	Content,
	HotFlg,
	NewFlg
	Status
*/
namespace TeduCoreApp.Domain.Entities
{
	[Table("Products")]
	public class Product : DomainEntity<int>, ISwitchable, IDateTracking, IHasSeoMetaData
	{
		// Tên sản phẩm
		[StringLength(255)]
		[Required]
		public string Name { get; set; }
		
		// Mã danh mục sản phẩm
		[Required]	
		public int CategoryId { get; set; }
		
		// Đường dẫn hình ảnh sản phẩm
		[StringLength(255)]
		public string Image { get; set; }
		
		// Giá bán sản phẩm
		[Required]
		[DefaultValue(0)]
		public decimal Price { get; set; }
		
		// Giá khuyến mãi
		public decimal? PromotionPrice { get; set; }
		
		// Giá gốc sản phẩm
		[Required]
		public decimal? OriginalPrice { get; set; }
		
		// Mô tả ngắn về sản phẩm
		public string Description { get; set; }
		
		// Nội dung chi tiết sản phẩm
		public string Content { get; set; }
		
		// Cờ hiển thị trên trang chủ
		public bool? HomeFlag { get; set; }
		
		// Cờ đánh dấu sản phẩm nổi bật
		public bool? HotFlag { get; set; }

		// Số lượt xem sản phẩm
		public int? ViewCount { get; set; }
		
		// Thẻ tags của sản phẩm
		[StringLength(255)]
		public string Tags { get; set; }
		
		// Đơn vị tính
		public string Unit { get; set; }

		// Trạng thái sản phẩm (Kích hoạt/Vô hiệu hóa)
		public Status Status { get; set; }
		
		// Ngày tạo sản phẩm
		public DateTime DateCreated { get; set; }
		
		// Ngày cập nhật sản phẩm
		public DateTime DateModified { get; set; }
		
		// Tiêu đề trang SEO
		public string SeoPageTitle { get; set; }
		
		// Đường dẫn thân thiện SEO
		[Column(TypeName = "varchar(255)")]
		public string SeoAlias { get; set; }
		
		// Từ khóa SEO
		[StringLength(255)]
		public string SeoKeywords { get; set; }
		
		// Mô tả SEO
		[StringLength(255)]
		public string SeoDescription { get; set; }

		// Quan hệ với bảng danh mục sản phẩm
		[ForeignKey("CategoryId")]
		public virtual ProductCategory ProductCategory { get; set; }
	}

}
