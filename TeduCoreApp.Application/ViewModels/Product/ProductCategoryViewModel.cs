using System.ComponentModel.DataAnnotations;
using TeduCoreApp.Domain.Enums;

namespace TeduCoreApp.Application.ViewModels.Product
{
	public class ProductCategoryViewModel
	{
		public int Id { get; set; }

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

		public  ICollection<ProductViewModel> Products { get; set; }

	}
}
