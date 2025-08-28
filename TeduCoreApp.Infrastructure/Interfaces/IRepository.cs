using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TeduCoreApp.Infrastructure.Interfaces
{
	public interface IRepository<T,K> where T : class
	{
		/// <summary>
		/// Tìm kiếm entity theo id
		/// </summary>
		/// <param name="id">Id của entity cần tìm</param>
		/// <param name="includeProperties">Danh sách các thuộc tính cần include</param>
		/// <returns>Entity tìm được</returns>
		T FindById(K id, params Expression<Func<T, object>>[] includeProperties);

		/// <summary>
		/// Tìm kiếm entity đầu tiên thỏa mãn điều kiện
		/// </summary>
		/// <param name="predicate">Điều kiện tìm kiếm</param>
		/// <param name="includeProperties">Danh sách các thuộc tính cần include</param>
		/// <returns>Entity tìm được</returns>
		T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

		/// <summary>
		/// Lấy tất cả entity
		/// </summary>
		/// <param name="includeProperties">Danh sách các thuộc tính cần include</param>
		/// <returns>Danh sách entity</returns>
		IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties);

		/// <summary>
		/// Lấy tất cả entity thỏa mãn điều kiện
		/// </summary>
		/// <param name="predicate">Điều kiện tìm kiếm</param>
		/// <param name="includeProperties">Danh sách các thuộc tính cần include</param>
		/// <returns>Danh sách entity</returns>
		IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

		/// <summary>
		/// Thêm mới entity
		/// </summary>
		/// <param name="entity">Entity cần thêm</param>
		void Add(T entity);

		/// <summary>	
		/// Giải phóng tài nguyên
		/// </summary>
		void Dispose();

		/// <summary>
		/// Cập nhật entity
		/// </summary>
		/// <param name="entity">Entity cần cập nhật</param>
		void Update(T entity);

		/// <summary>
		/// Xóa entity
		/// </summary>
		/// <param name="entity">Entity cần xóa</param>
		void Remove(T entity);

		/// <summary>
		/// Xóa entity theo id
		/// </summary>
		/// <param name="id">Id của entity cần xóa</param>
		void Remove(K id);

		/// <summary>
		/// Xóa nhiều entity
		/// </summary>
		/// <param name="entities">Danh sách entity cần xóa</param>
		void RemoveMultiple(List<T> entities);

		/// <summary>
		/// Lưu thay đổi vào database
		/// </summary>
		void SaveChanges();
	}
}
