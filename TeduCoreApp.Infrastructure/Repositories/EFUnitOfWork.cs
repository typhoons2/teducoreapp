using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Domain.Repositories;
using TeduCoreApp.Infrastructure.Persistence.DbContext;

namespace TeduCoreApp.Infrastructure.Repositories
{
    /// <summary>
    /// Lớp thực thi Unit of Work pattern sử dụng Entity Framework
    /// Unit of Work pattern giúp quản lý các thay đổi và commit tất cả các thay đổi vào database trong một transaction
    /// </summary>
    public class EFUnitOfWork : IUnitOfWork
    {
		/// <summary>
		/// DbContext để tương tác với database
		/// </summary>
		public readonly AppDbContext _context;

		/// <summary>
		/// Constructor khởi tạo EFUnitOfWork
		/// </summary>
		/// <param name="context">DbContext được inject vào</param>
		public EFUnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Lưu tất cả các thay đổi vào database
        /// Phương thức này sẽ commit tất cả các thay đổi đã được thực hiện trong một transaction
        /// </summary>
        public void Commit()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Giải phóng tài nguyên của DbContext
        /// Phương thức này được gọi khi không còn cần sử dụng UnitOfWork nữa
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
