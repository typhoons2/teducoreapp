using System.ComponentModel.DataAnnotations.Schema;
using TeduCoreApp.Domain.Enums;
using TeduCoreApp.Domain.Interfaces;
using TeduCoreApp.Domain.SharedKernel;

namespace TeduCoreApp.Domain.Entities
{
	[Table("AppUsers")]
    public class AppUser : DomainEntity<Guid>, IDateTracking, ISwitchable
    {
        // Tên đầy đủ của người dùng
        public string FullName { get; set; }

        // Ngày sinh của người dùng
        public DateTime? BirthDay { get; set; }

        // Số dư tài khoản của người dùng
        public decimal Balance { get; set; }

        // Đường dẫn hình ảnh của người dùng
        public string Avatar { get; set; }

        // Ngày tạo
        public DateTime DateCreated { get; set; }

        // Ngày cập nhật
        public DateTime DateModified { get; set; }

        // Trạng thái
        public Status Status { get; set; }
    }
}
