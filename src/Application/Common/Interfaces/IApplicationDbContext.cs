using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; }

        DbSet<TodoItem> TodoItems { get; }
        DbSet<Level> Levels { get; }
        DbSet<Subject> Subjects { get; }
        DbSet<Chapter> Chapters { get; }
        DbSet<Exercise> Exercises { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
