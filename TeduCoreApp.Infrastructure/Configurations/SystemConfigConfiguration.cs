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
	public class SystemConfigConfiguration : IEntityTypeConfiguration<SystemConfig>
	{
		public void Configure(EntityTypeBuilder<SystemConfig> entity)
		{
			entity.Property(e => e.Id).IsRequired().HasMaxLength(255).HasColumnType("varchar(255)");
		}
	}
}
