using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
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
using TeduCoreApp.Utilities.Dtos;

namespace TeduCoreApp.Application.Implementations
{
	public class ProductService : IProductService
	{
		private IUnitOfWork _unitOfWork;
		private IProductRepository _productRepository;
		public ProductService(IUnitOfWork unitOfWork, IProductRepository productRepository)
		{
			_unitOfWork = unitOfWork;
			_productRepository = productRepository;
		}
		
		public ProductViewModel Add(ProductViewModel productVm)
		{
			var product = Mapper.Map<Product>(productVm);
			_productRepository.Add(product);
			return productVm;
		}

		public void Delete(int id)
		{
			_productRepository.Remove(id);
		}

		public List<ProductViewModel> GetAll()
		{
			return _productRepository.FindAll(x => x.ProductCategory).ProjectTo<ProductViewModel>().ToList();
		}

		public List<ProductViewModel> GetAll(string keyword)
		{
			if (!string.IsNullOrEmpty(keyword))
			{
				return _productRepository
					.FindAll(x => x.Name.Contains(keyword) || x.Description.Contains(keyword), x => x.ProductCategory)
					.ProjectTo<ProductViewModel>()
					.ToList();
			}
			else
			{
				return _productRepository
					.FindAll(x => x.ProductCategory)
					.ProjectTo<ProductViewModel>()
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

			var data = query.ProjectTo<ProductViewModel>().ToList();

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
			return Mapper.Map<Product, ProductViewModel>(_productRepository.FindById(id, x => x.ProductCategory));
		}

		public void Save()
		{
			_unitOfWork.Commit();
		}

		public void Update(ProductViewModel productVm)
		{
			var product = Mapper.Map<Product>(productVm);
			_productRepository.Update(product);
		}
	}
} 