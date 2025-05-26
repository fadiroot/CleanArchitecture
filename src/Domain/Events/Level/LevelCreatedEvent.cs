namespace CleanArchitecture.Domain.Events.Level;

public class LevelCreatedEvent : BaseEvent
{
    public Entities.Level Level { get; }

    public LevelCreatedEvent(Entities.Level level)
    {
        Level = level;
    }
    
    
}