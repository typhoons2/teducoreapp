using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TeduCoreApp.Application.Interfaces;
using TeduCoreApp.Application.ViewModels.System;
using TeduCoreApp.Domain.Repositories;

namespace TeduCoreApp.Application.Implementations
{
	public class FunctionService : IFunctionService
	{
		private readonly IFunctionRepository _functionRepository;
		private readonly IConfigurationProvider _mapperConfig;

		public FunctionService(IFunctionRepository functionRepository, IMapper mapper)	
		{
			_functionRepository = functionRepository;
			_mapperConfig = mapper.ConfigurationProvider;
		}

		public async Task<List<FunctionViewModel>> GetAllAsync()
		{
			return await _functionRepository
				.FindAll()
				.ProjectTo<FunctionViewModel>(_mapperConfig)
				.ToListAsync();
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
