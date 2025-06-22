using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Application.ViewModels.Product;
using TeduCoreApp.Application.ViewModels.System;
using TeduCoreApp.Data.Entities;

namespace TeduCoreApp.Application.AutoMapper
{
	public class DomainToViewModelMappingProfile : Profile
	{
		public DomainToViewModelMappingProfile()
		{
			CreateMap<ProductCategory, ProductCategoryViewModel>();
			CreateMap<Function, FunctionViewModel>();
		}
	}
}
