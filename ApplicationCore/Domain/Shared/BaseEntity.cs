using System.ComponentModel.DataAnnotations.Schema;

namespace RecognitionCore.Domain.Shared;

public abstract class BaseEntity
{
    private List<BaseDomainEvent> _domainEvents = new();

    public int Id { get; set; }
    
    [NotMapped]
    public IReadOnlyList<BaseDomainEvent> DomainEvents { get; private set; }

    public void AddDomainEvent(BaseDomainEvent @event)
    {
        _domainEvents.Add(@event);
    }

    public void RemoveDomainEvent(BaseDomainEvent @event)
    {
        _domainEvents.Remove(@event);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}