using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Application.Interfaces;
using TeduCoreApp.Application.ViewModels.Product;
using TeduCoreApp.Data.Entities;
using TeduCoreApp.Data.Enums;
using TeduCoreApp.Data.IRepositories;
using TeduCoreApp.Infrastructure.Interfaces;

namespace TeduCoreApp.Application.Implementations
{
	public class ProductCategoryService : IProductCategoryService
	{
		private IUnitOfWork _unitOfWork;
		private IProductCategoryRepository _productCategoryRepository;
		public ProductCategoryService(IUnitOfWork unitOfWork, IProductCategoryRepository productCategoryRepository)
		{

			_unitOfWork = unitOfWork;
			_productCategoryRepository = productCategoryRepository;
		}
		
		public ProductCategoryViewModel Add(ProductCategoryViewModel productCategoryVm)
		{
			var productCategory = Mapper.Map<ProductCategory>(productCategoryVm);
			_productCategoryRepository.Add(productCategory);
			return productCategoryVm;
		}

		public void Delete(int id)
		{
			_productCategoryRepository.Remove(id);
		}

		public List<ProductCategoryViewModel> GetAll()
		{
			return _productCategoryRepository.FindAll().OrderBy(x => x.ParentId).ProjectTo<ProductCategoryViewModel>().ToList();
		}

		public List<ProductCategoryViewModel> GetAll(string keyword)
		{
			if (!string.IsNullOrEmpty(keyword))
			{
				return _productCategoryRepository
					.FindAll(x => x.Name.Contains(keyword) || x.Description.Contains(keyword))
					.OrderBy(x => x.ParentId)
					.ProjectTo<ProductCategoryViewModel>()
					.ToList();
			}
			else
			{
				return _productCategoryRepository
					.FindAll()
					.OrderBy(x => x.ParentId)
					.ProjectTo<ProductCategoryViewModel>()
					.ToList();
			}
		}

		public List<ProductCategoryViewModel> GetAllByParentId(int parentId)
		{
			return _productCategoryRepository
				.FindAll(x => x.Status == Status.Active && x.ParentId == parentId)
				.ProjectTo<ProductCategoryViewModel>()
				.ToList();
		}

		public ProductCategoryViewModel GetById(int id)
		{
			return Mapper.Map<ProductCategory, ProductCategoryViewModel>(_productCategoryRepository.FindById(id));
		}

		public void ReOrder(int sourceId, int targetId)
		{
			throw new NotImplementedException();
		}

		public void Save()
		{
			_unitOfWork.Commit();
		}

		public void Update(ProductCategoryViewModel productCategoryVm)
		{
			throw new NotImplementedException();
		}

		public List<ProductCategoryViewModel> UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items)
		{
			throw new NotImplementedException();
		}
	}
}
