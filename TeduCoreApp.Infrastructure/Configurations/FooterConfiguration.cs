using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeduCoreApp.Domain.Entities;

namespace TeduCoreApp.Infrastructure.Configurations
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
