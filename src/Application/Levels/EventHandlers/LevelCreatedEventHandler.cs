using CleanArchitecture.Domain.Events.Level;
using Microsoft.Extensions.Logging;

namespace Microsoft.Extensions.DependencyInjection.Levels.EventHandlers
{
    public class LevelCreatedEventHandler : INotificationHandler<LevelCreatedEvent>
    {
        private readonly ILogger<LevelCreatedEventHandler> _logger;

        public LevelCreatedEventHandler(ILogger<LevelCreatedEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(LevelCreatedEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("LevelCreatedEventHandler.Handle");
            _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", notification.GetType().Name);
            return Task.CompletedTask;
        }
    }
}
