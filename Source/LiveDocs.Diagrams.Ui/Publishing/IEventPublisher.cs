namespace LiveDocs.Diagrams.Ui.Publishing
{
    using LiveDocs.Diagrams.Ui.Events;

    public interface IEventPublisher<TPublisher>        
    {
        void Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}