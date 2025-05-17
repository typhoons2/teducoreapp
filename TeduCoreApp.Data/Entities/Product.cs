using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Data.Enums;
using TeduCoreApp.Data.Interfaces;
using TeduCoreApp.Infrastructure.SharedKernel;


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
namespace TeduCoreApp.Data.Entities
{
	[Table("Products")]
	public class Product : DomainEntity<int>, ISwitchable, IDateTracking, IHasSeoMetaData
	{
		[StringLength(255)]
		[Required]
		public string Name { get; set; }
		[Required]	
		public int CategoryId { get; set; }
		[StringLength(255)]
		public string Image { get; set; }
		[Required]
		[DefaultValue(0)]
		public decimal Price { get; set; }
		
		public decimal? PromotionPrice { get; set; }
		[Required]
		public decimal? OriginalPrice { get; set; }
		public string Description { get; set; }
		public string Content { get; set; }
		public bool? HomeFlag { get; set; }
		public bool? HotFlag { get; set; }

		public int? ViewCount { get; set; }
		[StringLength(255)]
		public string Tags { get; set; }
		public string Unit { get; set; }


		public Status Status { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateModified { get; set; }
		public string SeoPageTitle { get; set; }
		[Column(TypeName = "varchar(255)")]
		public string SeoAlias { get; set; }	
		[StringLength(255)]
		public string SeoKeywords { get; set; }
		[StringLength(255)]
		public string SeoDescription { get; set; }

		[ForeignKey("CategoryId")]
		public virtual ProductCategory ProductCategory { get; set; }
	}

}
