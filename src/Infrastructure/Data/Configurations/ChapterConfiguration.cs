using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Data.Configurations
{
    public class ChapterConfiguration : IEntityTypeConfiguration<Chapter>
    {
        public void Configure(EntityTypeBuilder<Chapter> builder)
        {
            builder.Property(c => c.Title).HasMaxLength(100).IsRequired();
            builder.HasOne(c=>c.Subject)
                .WithMany(s =>s.Chapters)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
