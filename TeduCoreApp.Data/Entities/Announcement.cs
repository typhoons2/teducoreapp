using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Data.Enums;
using TeduCoreApp.Data.Interfaces;
using TeduCoreApp.Infrastructure.SharedKernel;

namespace TeduCoreApp.Data.Entities
{
	 [Table("Announcements")]
    public class Announcement  : DomainEntity<string>,ISwitchable,IDateTracking
    {
        public Announcement()
        {
            AnnouncementUsers = new List<AnnouncementUser>();
        }

        // Tiêu đề thông báo
        [Required]
        [StringLength(250)]
        public string Title { set; get; }

        // Nội dung thông báo
        [StringLength(250)]
        public string Content { set; get; }

        // Mã người dùng
        [StringLength(450)]
        public string UserId { set; get; }

        // Quan hệ với bảng người dùng
        [ForeignKey("UserId")]
        public virtual AppUser AppUser { get; set; }

        // Tập hợp các thông báo người dùng
        public virtual ICollection<AnnouncementUser> AnnouncementUsers { get; set; }

        // Ngày tạo
        public DateTime DateCreated { set; get; }

        // Ngày cập nhật
        public DateTime DateModified { set; get; }

        // Trạng thái
        public Status Status { set; get; }
		
	}
}
