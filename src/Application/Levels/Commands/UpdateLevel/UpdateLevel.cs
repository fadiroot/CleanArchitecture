using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities;

namespace Microsoft.Extensions.DependencyInjection.Levels.Commands.UpdateLevel;

public class UpdateLevelCommand: IRequest
{
    public int Id { get; init; }
    public string Name { get; init; } = String.Empty;
    
}
public class UpdateLevelCommandHandler : IRequestHandler<UpdateLevelCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateLevelCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateLevelCommand request, CancellationToken cancellationToken)
    {
        
        var level = await _context.Levels
            .FirstOrDefaultAsync(l => l.Id == request.Id, cancellationToken);
        Guard.Against.NotFound(request.Id, level);
        Level.Update(level , request.Name);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
