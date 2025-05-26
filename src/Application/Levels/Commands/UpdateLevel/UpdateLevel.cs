using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities;

namespace Microsoft.Extensions.DependencyInjection.Levels.Commands.UpdateLevel;

public class UpdateLevelCommand: IRequest<Result>
{
    public int Id { get; init; }
    public string? Name { get; init; }
    
}
public class UpdateLevelCommandHandler : IRequestHandler<UpdateLevelCommand, Result>
{
    private readonly IApplicationDbContext _context;

    public UpdateLevelCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result> Handle(UpdateLevelCommand request, CancellationToken cancellationToken)
    {
        // 1. Validate input
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return Result.Failure(new[] { "Name is required" });
        }

        // 2. Find the level
        var level = await _context.Levels
            .FirstOrDefaultAsync(l => l.Id == request.Id, cancellationToken);

        if (level == null)
        {
            return Result.Failure(new[] { "Level not found" });
        }

        level.Name = request.Name;

        // 4. Save changes
        try
        {
            await _context.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
        catch (DbUpdateException)
        {
            return Result.Failure(new[] { "Failed to update level" });
        }
    }
}
