using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduCoreApp.Domain.SharedKernel;

namespace TeduCoreApp.Domain.Entities
{
	 [Table("AdvertistmentPositions")]
    public class AdvertistmentPosition : DomainEntity<string>
    {
        // Mã trang quảng cáo
        [StringLength(20)]
        public string PageId { get; set; }

        // Tên vị trí quảng cáo
        [StringLength(250)]
        public string Name { get; set; }

        // Quan hệ với bảng trang quảng cáo
        [ForeignKey("PageId")]
        public virtual AdvertistmentPage AdvertistmentPage { get; set; }

        // Tập hợp các quảng cáo thuộc vị trí này
        public virtual ICollection<Advertistment> Advertistments { get; set; }
    }
}
