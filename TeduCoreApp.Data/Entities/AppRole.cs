using Microsoft.AspNetCore.Identity; // <-- Dòng này rất quan trọng!
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace TeduCoreApp.Data.Entities
{
	[Table("AppRoles")]
	public class AppRole : IdentityRole<Guid>
	{
		public AppRole() : base()
		{

		}
		public AppRole(string name, string description) : base(name)
		{
			this.Description = description;
		}

		[StringLength(250)]
		public string Description { get; set; }
	}
}