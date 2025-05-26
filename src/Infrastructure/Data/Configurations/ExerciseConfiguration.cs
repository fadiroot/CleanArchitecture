using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Data.Configurations
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.Property(e => e.Title).HasMaxLength(200).IsRequired();
            builder.HasOne(e=>e.Chapter) .WithMany(c=>c.Exercises).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
