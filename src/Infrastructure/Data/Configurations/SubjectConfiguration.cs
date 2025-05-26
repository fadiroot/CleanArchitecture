using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Data.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.Property(s=>s.Name).HasMaxLength(100).IsRequired();
            builder.HasOne(s => s.Level)
                .WithMany(l => l.Subjects)
                .HasForeignKey(s => s.LevelId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

