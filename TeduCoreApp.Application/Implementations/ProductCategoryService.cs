using AutoMapper;
using AutoMapper.QueryableExtensions;
using TeduCoreApp.Application.Interfaces;
using TeduCoreApp.Application.ViewModels.Product;
using TeduCoreApp.Domain.Entities;
using TeduCoreApp.Domain.Enums;
using TeduCoreApp.Domain.Repositories;

namespace TeduCoreApp.Application.Implementations
{
	public class ProductCategoryService : IProductCategoryService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IProductCategoryRepository _productCategoryRepository;
		private readonly IMapper _mapper;
		private readonly IConfigurationProvider _mapperConfig;

		public ProductCategoryService(IUnitOfWork unitOfWork, IProductCategoryRepository productCategoryRepository, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_productCategoryRepository = productCategoryRepository;
			_mapper = mapper;
			_mapperConfig = mapper.ConfigurationProvider;
		}

		public ProductCategoryViewModel Add(ProductCategoryViewModel productCategoryVm)
		{
			var productCategory = _mapper.Map<ProductCategory>(productCategoryVm);
			_productCategoryRepository.Add(productCategory);
			return productCategoryVm;
		}

		public void Delete(int id)
		{
			_productCategoryRepository.Remove(id);
		}

		public List<ProductCategoryViewModel> GetAll()
		{
			return _productCategoryRepository
				.FindAll()
				.OrderBy(x => x.ParentId)
				.ThenBy(x => x.SortOrder)
				.ProjectTo<ProductCategoryViewModel>(_mapperConfig)
				.ToList();
		}

		public List<ProductCategoryViewModel> GetAll(string keyword)
		{
			if (!string.IsNullOrEmpty(keyword))
			{
				return _productCategoryRepository
					.FindAll(x => x.Name.Contains(keyword) || x.Description.Contains(keyword))
					.OrderBy(x => x.ParentId)
					.ThenBy(x => x.SortOrder)
					.ProjectTo<ProductCategoryViewModel>(_mapperConfig)
					.ToList();
			}
			else
			{
				return _productCategoryRepository
					.FindAll()
					.OrderBy(x => x.ParentId)
					.ProjectTo<ProductCategoryViewModel>(_mapperConfig)
					.ToList();
			}
		}

		public List<ProductCategoryViewModel> GetAllByParentId(int parentId)
		{
			return _productCategoryRepository
				.FindAll(x => x.Status == Status.Active && x.ParentId == parentId)
				.ProjectTo<ProductCategoryViewModel>(_mapperConfig)
				.ToList();
		}

		public ProductCategoryViewModel GetById(int id)
		{
			return _mapper.Map<ProductCategory, ProductCategoryViewModel>(_productCategoryRepository.FindById(id));
		}

		public void ReOrder(int sourceId, int targetId)
		{
			var source = _productCategoryRepository.FindById(sourceId);
			var target = _productCategoryRepository.FindById(targetId);
			
			// Đơn giản: hoán đổi sortOrder
			var tempOrder = source.SortOrder;
			source.SortOrder = target.SortOrder;
			target.SortOrder = tempOrder;
			
			_productCategoryRepository.Update(source);
			_productCategoryRepository.Update(target);
		}

		public void Save()
		{
			_unitOfWork.Commit();
		}

		public void Update(ProductCategoryViewModel productCategoryVm)
		{
			// Lấy ra entity hiện tại
			var productCategory = _productCategoryRepository.FindById(productCategoryVm.Id);

			// Map các thay đổi từ ViewModel sang entity
			_mapper.Map(productCategoryVm, productCategory);

			// Cập nhật lại entity
			_productCategoryRepository.Update(productCategory);
		}

		public void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items)
		{
			var sourceCategory = _productCategoryRepository.FindById(sourceId);
			sourceCategory.ParentId = targetId;

			// Cập nhật sortOrder cho item được kéo thả
			if (items.ContainsKey(sourceId))
			{
				sourceCategory.SortOrder = items[sourceId];
			}

			_productCategoryRepository.Update(sourceCategory);

			// Lấy danh sách key
			var keys = items.Keys.ToList();

			// Get all sibling
			var sibling = _productCategoryRepository.FindAll(x => keys.Contains(x.Id));
			foreach (var child in sibling)
			{
				child.SortOrder = items[child.Id];
				_productCategoryRepository.Update(child);
			}
		}


	}
}
