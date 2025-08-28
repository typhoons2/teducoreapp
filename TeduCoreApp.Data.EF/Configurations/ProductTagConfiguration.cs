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
	public class ProductTagConfiguration : IEntityTypeConfiguration<ProductTag>
	{
		public void Configure(EntityTypeBuilder<ProductTag> entity)
		{
			entity.Property(e => e.TagId).IsRequired().HasColumnType("varchar(255)");
		}
	}
}
