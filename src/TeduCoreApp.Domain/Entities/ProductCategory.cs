using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Data.Interfaces;
using TeduCoreApp.Data.Enums;
using TeduCoreApp.Infrastructure.SharedKernel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TeduCoreApp.Data.Entities
{
	[Table("ProductCategories")]
	public class ProductCategory : DomainEntity<int>, IHasSeoMetaData, ISwitchable, IDateTracking, ISortable
	{
		/*
		Product Category
		Id
		Alias
		Name
		ParentId
		Seo
		CreatedDate,
		SortingOrder
		Status
		*/
		public ProductCategory()
		{
			Products = new List<Product>();
		}

		public ProductCategory(string name, string description, int? homeOrder, string image, bool? homeFlag, string seoPageTitle, string seoAlias, string seoKeywords, string seoDescription, Status status, int sortOrder)
		{
			Name = name;
			Description = description;
			HomeOrder = homeOrder;
			Image = image;
			HomeFlag = homeFlag;
			SeoPageTitle = seoPageTitle;
			SeoAlias = seoAlias;
			SeoKeywords = seoKeywords;
			SeoDescription = seoDescription;
			Status = status;
			SortOrder = sortOrder;
		}
		[StringLength(255)]
		[Required]
		public string Name { get; set; }
		[StringLength(255)]
		public string Description { get; set; }
		public int? ParentId { get; set; }
		public int? HomeOrder { get; set; }
		[StringLength(255)]
		public string Image { get; set; }
		public bool? HomeFlag { get; set; }

		[StringLength(255)]
		public string SeoPageTitle { get; set; }
		[StringLength(255)]
		public string SeoAlias { get; set; }
		[StringLength(255)]
		public string SeoKeywords { get; set; }
		[StringLength(255)]
		public string SeoDescription { get; set; }
		public Status Status { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateModified { get; set; }
		public int SortOrder { get; set; }

		public virtual ICollection<Product> Products { get; set; }
	}
}
