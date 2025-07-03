using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeduCoreApp.Data.Entities;

namespace TeduCoreApp.Data.EF.Configurations
{
	public class ContactDetailConfiguration : IEntityTypeConfiguration<Contact>
	{
		public void Configure(EntityTypeBuilder<Contact> entity)
		{
			entity.HasKey(c => c.Id);
			entity.Property(c => c.Id).IsRequired().HasMaxLength(250).HasColumnType("varchar(250)");
		}
	}
}
