using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeduCoreApp.Domain.Entities;

namespace TeduCoreApp.Infrastructure.Configurations
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
