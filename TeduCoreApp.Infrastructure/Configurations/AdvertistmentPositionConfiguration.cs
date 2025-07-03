using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeduCoreApp.Domain.Entities;

namespace TeduCoreApp.Infrastructure.Configurations
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
