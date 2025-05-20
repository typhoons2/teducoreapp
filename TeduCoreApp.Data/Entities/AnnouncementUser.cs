using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Infrastructure.SharedKernel;

namespace TeduCoreApp.Data.Entities
{
	[Table("AnnouncementUsers")]
    public class AnnouncementUser : DomainEntity<int>
    {
        // Mã thông báo
        [StringLength(128)]
        [Required]
        public string AnnouncementId { get; set; }

        // Mã người dùng
        [Required]
        public Guid UserId { get; set; }

        // Cờ đã đọc thông báo
        public bool? HasRead { get; set; }

        // Quan hệ với bảng người dùng
        [ForeignKey("UserId")]
        public virtual AppUser AppUser { get; set; }

        // Quan hệ với bảng thông báo
        [ForeignKey("AnnouncementId")]
        public virtual Announcement Announcement { get; set; }
    }
}
