using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Data.Entities;

namespace TeduCoreApp.Data.EF.Configurations
{
	public class AdvertistmentPageConfiguration : IEntityTypeConfiguration<AdvertistmentPage>
	{
		public void Configure(EntityTypeBuilder<AdvertistmentPage> entity)
		{
			entity.Property(c => c.Id)
				.HasMaxLength(20)
				.IsRequired()
				.HasColumnType("varchar(20)");
		}
	}
}
