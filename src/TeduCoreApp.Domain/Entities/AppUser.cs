using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Data.Enums;
using TeduCoreApp.Data.Interfaces;

namespace TeduCoreApp.Data.Entities
{
	[Table("AppUsers")]
    public class AppUser : IdentityUser<Guid>, IDateTracking, ISwitchable
    {
        // Tên đầy đủ của người dùng
        public string FullName { get; set; }

        // Ngày sinh của người dùng
        public DateTime? BirthDay { set; get; }

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
