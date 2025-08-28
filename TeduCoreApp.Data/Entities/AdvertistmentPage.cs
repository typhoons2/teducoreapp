using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Infrastructure.SharedKernel;

namespace TeduCoreApp.Data.Entities
{
	[Table("AdvertistmentPages")]
    public class AdvertistmentPage : DomainEntity<string>
    {
        // Tên trang quảng cáo
        public string Name { get; set; }

        // Tập hợp các vị trí quảng cáo thuộc trang này
        public virtual ICollection<AdvertistmentPosition> AdvertistmentPositions { get; set; }
    }
}
