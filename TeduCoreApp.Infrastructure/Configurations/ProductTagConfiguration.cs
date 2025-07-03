using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Domain.Entities;

namespace TeduCoreApp.Infrastructure.Configurations
{
	public class ProductTagConfiguration : IEntityTypeConfiguration<ProductTag>
	{
		public void Configure(EntityTypeBuilder<ProductTag> builder)
		{
			builder.Property(x => x.TagId)
				.HasMaxLength(50)
				.IsRequired()
				.HasColumnType("varchar(50)");
		}
	}
}
