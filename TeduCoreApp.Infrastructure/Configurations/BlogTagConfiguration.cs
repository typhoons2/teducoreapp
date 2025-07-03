using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeduCoreApp.Domain.Entities;

namespace TeduCoreApp.Infrastructure.Configurations
{
	public class BlogTagConfiguration : IEntityTypeConfiguration<BlogTag>
	{
		public void Configure(EntityTypeBuilder<BlogTag> entity)
		{
			entity.Property(c => c.Id).IsRequired().HasMaxLength(255).HasColumnType("varchar(255)");
		}
	}
}
