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
	public class PageConfiguration : IEntityTypeConfiguration<Page>
	{
		public void Configure(EntityTypeBuilder<Page> entity)
		{
			entity.HasKey(entity => entity.Id);
			entity.Property(entity => entity.Id).IsRequired().HasMaxLength(255).HasColumnType("varchar(255)");
		}
	}
}
