using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduCoreApp.Data.Enums;
using TeduCoreApp.Data.Interfaces;
using TeduCoreApp.Infrastructure.SharedKernel;

namespace TeduCoreApp.Data.Entities
{
	[Table("Advertistments")]
    public class Advertistment : DomainEntity<int>, ISwitchable, ISortable
    {
        // Tên quảng cáo
        [StringLength(250)]
        public string Name { get; set; }

        // Mô tả quảng cáo
        [StringLength(250)]
        public string Description { get; set; }

        // Đường dẫn hình ảnh quảng cáo
        [StringLength(250)]
        public string Image { get; set; }

        // Đường dẫn URL khi click vào quảng cáo
        [StringLength(250)]
        public string Url { get; set; }

        // Mã vị trí quảng cáo
        [StringLength(20)]
        public string PositionId { get; set; }

        // Trạng thái quảng cáo (Kích hoạt/Vô hiệu hóa)
        public Status Status { set; get; }
        
        // Ngày tạo quảng cáo
        public DateTime DateCreated { set; get; }
        
        // Ngày cập nhật quảng cáo
        public DateTime DateModified { set; get; }
        
        // Thứ tự sắp xếp
        public int SortOrder { set; get; }

        // Quan hệ với bảng vị trí quảng cáo
        [ForeignKey("PositionId")]
        public virtual AdvertistmentPosition AdvertistmentPosition { get; set; }
		
	}
}
