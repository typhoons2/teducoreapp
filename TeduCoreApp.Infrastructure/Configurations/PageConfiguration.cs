using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeduCoreApp.Domain.Entities;

namespace TeduCoreApp.Infrastructure.Configurations
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
