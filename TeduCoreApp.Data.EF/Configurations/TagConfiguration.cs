using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeduCoreApp.Data.Entities;

namespace TeduCoreApp.Data.EF.Configurations
{
	public class TagConfiguration : IEntityTypeConfiguration<Tag>
	{
		public void Configure(EntityTypeBuilder<Tag> entity)
		{	
			entity.Property(c => c.Id)
				.HasMaxLength(50)
				.IsRequired()
				.HasColumnType("varchar(50)");
		}
	}
}	