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
	public class FunctionConfiguration : IEntityTypeConfiguration<Function>
	{
		public void Configure(EntityTypeBuilder<Function> entity)
		{
			entity.HasKey(e => e.Id);
			entity.Property(e => e.Id).IsRequired().HasColumnType("varchar(128)");
		}
	}
}
