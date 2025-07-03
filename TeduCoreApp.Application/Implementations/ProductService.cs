using AutoMapper;
using AutoMapper.QueryableExtensions;
using TeduCoreApp.Application.Interfaces;
using TeduCoreApp.Application.ViewModels.Product;
using TeduCoreApp.Domain.Entities;
using TeduCoreApp.Domain.Enums;
using TeduCoreApp.Domain.Repositories;
using TeduCoreApp.Utilities.Dtos;

namespace TeduCoreApp.Application.Implementations
{
	public class ProductService : IProductService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IProductRepository _productRepository;
		private readonly IMapper _mapper;
		private readonly IConfigurationProvider _mapperConfig;

		public ProductService(IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_productRepository = productRepository;
			_mapper = mapper;
			_mapperConfig = mapper.ConfigurationProvider;
		}
		
		public ProductViewModel Add(ProductViewModel productVm)
		{
			var product = _mapper.Map<Product>(productVm);
			_productRepository.Add(product);
			return productVm;
		}

		public void Delete(int id)
		{
			_productRepository.Remove(id);
		}

		public List<ProductViewModel> GetAll()
		{
			return _productRepository
				.FindAll(x => x.ProductCategory)
				.ProjectTo<ProductViewModel>(_mapperConfig)
				.ToList();
		}

		public List<ProductViewModel> GetAll(string keyword)
		{
			if (!string.IsNullOrEmpty(keyword))
			{
				return _productRepository
					.FindAll(x => x.Name.Contains(keyword) || x.Description.Contains(keyword), x => x.ProductCategory)
					.ProjectTo<ProductViewModel>(_mapperConfig)
					.ToList();
			}
			else
			{
				return _productRepository
					.FindAll(x => x.ProductCategory)
					.ProjectTo<ProductViewModel>(_mapperConfig)
					.ToList();
			}
		}

		public PagedResult<ProductViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize)
		{
			var query = _productRepository.FindAll(x => x.Status == Status.Active);
			if (!string.IsNullOrEmpty(keyword))
				query = query.Where(x => x.Name.Contains(keyword));
			if (categoryId.HasValue)
				query = query.Where(x => x.CategoryId == categoryId.Value);

			int totalRow = query.Count();

			query = query.OrderByDescending(x => x.DateCreated)
				.Skip((page - 1) * pageSize).Take(pageSize);

			var data = query.ProjectTo<ProductViewModel>(_mapperConfig).ToList();

			var paginationSet = new PagedResult<ProductViewModel>()
			{
				Results = data,
				CurrentPage = page,
				RowCount = totalRow,
				PageSize = pageSize
			};
			return paginationSet;
		}

		public ProductViewModel GetById(int id)
		{
			return _mapper.Map<ProductViewModel>(_productRepository.FindById(id, x => x.ProductCategory));
		}

		public void Save()
		{
			_unitOfWork.Commit();
		}

		public void Update(ProductViewModel productVm)
		{
			var product = _mapper.Map<Product>(productVm);
			_productRepository.Update(product);
		}
	}
} 