using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Events.Level;

namespace Microsoft.Extensions.DependencyInjection.Levels.Commands.CreateLevel
{
    public class CreateLevelCommand : IRequest<Level>
    {
        public string Name { get; init; } = String.Empty;
    
    }

    public class CreateLevelCommandHandler : IRequestHandler<CreateLevelCommand, Level>
    {
        private readonly IApplicationDbContext _context;

        public CreateLevelCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Level> Handle(CreateLevelCommand request, CancellationToken cancellationToken)
        {
            var entity =  Level.Create (request.Name );
            entity.AddDomainEvent(new LevelCreatedEvent(entity));

            _context.Levels.Add (entity);
            await _context.SaveChangesAsync(cancellationToken);
        
            return entity;
        
        }
    }
}
