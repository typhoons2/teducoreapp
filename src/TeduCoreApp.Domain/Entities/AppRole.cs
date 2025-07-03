using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduCoreApp.Domain.SharedKernel;

namespace TeduCoreApp.Domain.Entities
{
	[Table("AppRoles")]
	public class AppRole : DomainEntity<Guid>
	{
		public AppRole() { }

		public AppRole(string name, string description)
		{
			Name        = name;
			Description = description;
		}

		[Required, StringLength(250)]
		public string Name { get; private set; }

		[StringLength(250)]
		public string Description { get; private set; }
	}
}