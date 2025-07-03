using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Domain.SharedKernel;
using System.ComponentModel.DataAnnotations;

namespace TeduCoreApp.Domain.Entities
{
	[Table("AdvertistmentPages")]
    public class AdvertistmentPage : DomainEntity<string>
    {
        [StringLength(20)]
        public override string Id { get; set; }

        // Tên trang quảng cáo
        public string Name { get; set; }

        // Tập hợp các vị trí quảng cáo thuộc trang này
        public virtual ICollection<AdvertistmentPosition> AdvertistmentPositions { get; set; }
    }
}
