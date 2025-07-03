using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeduCoreApp.Domain.Entities;

namespace TeduCoreApp.Infrastructure.Configurations
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
