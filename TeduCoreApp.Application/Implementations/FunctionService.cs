using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TeduCoreApp.Application.Interfaces;
using TeduCoreApp.Application.ViewModels.System;
using TeduCoreApp.Data.IRepositories;

namespace TeduCoreApp.Application.Implementations
{
	public class FunctionService : IFunctionService
	{
		private IFunctionRepository _functionRepository;

		public FunctionService(IFunctionRepository functionRepository)	
		{
			_functionRepository = functionRepository;
		}

		public async Task<List<FunctionViewModel>> GetAllAsync()
		{
			return await _functionRepository.FindAll().ProjectTo<FunctionViewModel>().ToListAsync();
		}

		

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}

		public async Task<List<FunctionViewModel>> GetAllByPermissionAsync(Guid userId)
		{
			throw new NotImplementedException();
		}
	}
}
