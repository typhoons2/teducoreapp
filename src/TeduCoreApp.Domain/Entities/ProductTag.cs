using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Domain.SharedKernel;

namespace TeduCoreApp.Domain.Entities
{
	[Table("ProductTags")]
	public class ProductTag: DomainEntity<int>
	{
		public int ProductId { get; set; }
		[Column(TypeName = "varchar(50)")]
		public string TagId { get; set; }
		[ForeignKey("ProductId")]
		public virtual Product Product { get; set; }
		[ForeignKey("TagId")]
		public virtual Tag Tag { get; set; }
	}
}
