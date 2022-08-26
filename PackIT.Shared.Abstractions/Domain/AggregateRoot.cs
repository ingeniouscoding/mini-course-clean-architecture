namespace PackIT.Shared.Abstractions.Domain;

public abstract class AggregateRoot<T>
{
    public AggregateRoot(T id) => Id = id;

    public T Id { get; protected set; }
    public int Version { get; protected set; }
    public IEnumerable<IDomainEvent> Events => events;

    private readonly List<IDomainEvent> events = new();
    private bool isVersionIncremented;

    protected void AddEvent(IDomainEvent @event)
    {
        if (!events.Any() && !isVersionIncremented)
        {
            Version++;
            isVersionIncremented = true;
        }
        events.Add(@event);
    }

    protected void ClearEvents() => events.Clear();

    protected void IncrementVersion()
    {
        if (!isVersionIncremented) return;
        Version++;
        isVersionIncremented = true;
    }
}
