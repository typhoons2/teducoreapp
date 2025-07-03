using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TeduCoreApp.Domain.Repositories;
using TeduCoreApp.Domain.SharedKernel;
using TeduCoreApp.Infrastructure.Persistence.DbContext;

namespace TeduCoreApp.Infrastructure.Repositories
{
	public class EFRepository<T, K> : IRepository<T, K> where T : DomainEntity<K>
	{
		private readonly AppDbContext _context;
		public EFRepository(AppDbContext context)
		{
			_context = context;
			
		}
		

		public IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties)
		{
			IQueryable<T> items = _context.Set<T>();
			if (includeProperties.Any())
			{
				foreach (var includeProperty in includeProperties)
				{
					items = items.Include(includeProperty);
				}
			}
			return items;
		}

		public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
		{
			IQueryable<T> items = _context.Set<T>();
			if (includeProperties.Any())
			{
				foreach (var includeProperty in includeProperties)
				{
					items = items.Include(includeProperty);
				}
			}
			return items.Where(predicate);
		}

		public T FindById(K id, params Expression<Func<T, object>>[] includeProperties)
		{
			return FindAll(includeProperties).FirstOrDefault(x => x.Id.Equals(id));
		}

		public T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
		{
			return FindAll(includeProperties).FirstOrDefault(predicate);
		}

		public void Remove(T entity)
		{
			_context.Set<T>().Remove(entity);
		}

		public void Remove(K id)
		{
			var entity = FindById(id);
			if (entity != null)
			{
				Remove(entity);
			}
		}

		public void RemoveMultiple(List<T> entities)
		{
			_context.Set<T>().RemoveRange(entities);
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		public void Update(T entity)
		{
			_context.Set<T>().Update(entity);
		}

		public void Add(T entity)
		{
			_context.Add(entity);
		}

		public void Dispose()
		{
			if (_context != null)
			{
				_context.Dispose();
			}
		}
	}
}
