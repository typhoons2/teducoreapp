using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Data.Entities;

namespace TeduCoreApp.Data.EF.Configurations
{
	public class BlogTagConfiguration : IEntityTypeConfiguration<BlogTag>
	{
		public void Configure(EntityTypeBuilder<BlogTag> entity)
		{
			entity.Property(c => c.Id).IsRequired().HasMaxLength(255).HasColumnType("varchar(255)");
		}
	}
}
