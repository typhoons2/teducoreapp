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
	public class FooterConfiguration : IEntityTypeConfiguration<Footer>
	{
		public void Configure(EntityTypeBuilder<Footer> entity)
		{
			entity.HasKey(e => e.Id);
			entity.Property(e => e.Id).IsRequired().HasMaxLength(250).HasColumnType("varchar(250)");
		}
	}
}
