using AutoMapper;
using TeduCoreApp.Application.ViewModels.Product;
using TeduCoreApp.Domain.Entities;

namespace TeduCoreApp.Application.AutoMapper
{
	public class ViewModelToDomainMappingProfile : Profile
	{
		public ViewModelToDomainMappingProfile()
		{
			CreateMap<ProductCategoryViewModel, ProductCategory>().ConstructUsing(c => new ProductCategory(c.Name, c.Description, c.HomeOrder, c.Image, c.HomeFlag, c.SeoPageTitle, c.SeoAlias, c.SeoKeywords, c.SeoDescription, c.Status, c.SortOrder));
			CreateMap<ProductViewModel, Product>();
		}
	}
}
