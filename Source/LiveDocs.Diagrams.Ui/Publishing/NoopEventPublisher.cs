namespace LiveDocs.Diagrams.Ui.Publishing
{
    using LiveDocs.Diagrams.Ui.Events;

    public class NoopEventPublisher<TLogger> : IEventPublisher<TLogger>
    {
        public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {            
        }
    }
}