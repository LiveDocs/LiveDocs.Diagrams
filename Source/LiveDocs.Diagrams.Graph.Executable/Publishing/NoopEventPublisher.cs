namespace LiveDocs.Diagrams.Graph.Executable.Publishing
{
    using LiveDocs.Diagrams.Graph.Executable.Events;

    public class NoopEventPublisher<TLogger> : IEventPublisher<TLogger>
    {
        public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {            
        }
    }
}