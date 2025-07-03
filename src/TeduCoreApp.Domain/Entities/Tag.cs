using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduCoreApp.Domain.SharedKernel;

namespace TeduCoreApp.Domain.Entities
{
	public class Tag : DomainEntity<string>
	{
		[MaxLength(50)]
		[Required]
		public string Name { get; set; }

		[MaxLength(50)]
		[Required]
		public string Type { get; set; }
	}
}
