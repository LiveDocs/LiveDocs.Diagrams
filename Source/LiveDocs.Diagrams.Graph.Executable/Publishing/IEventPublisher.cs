namespace LiveDocs.Diagrams.Graph.Executable.Publishing
{
    using LiveDocs.Diagrams.Graph.Executable.Events;

    public interface IEventPublisher<TPublisher>        
    {
        void Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}