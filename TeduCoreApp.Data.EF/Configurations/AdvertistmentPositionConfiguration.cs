using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeduCoreApp.Data.Entities;

namespace TeduCoreApp.Data.EF.Configurations
{
    public class AdvertistmentPositionConfiguration : IEntityTypeConfiguration<AdvertistmentPosition>
    {
        public void Configure(EntityTypeBuilder<AdvertistmentPosition> entity)
        {
            entity.Property(c => c.Id)
                .HasMaxLength(20)
                .IsRequired()
                .HasColumnType("varchar(20)");
        }
    }
}
