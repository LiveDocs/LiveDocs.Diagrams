namespace LiveDocs.Diagrams.Ui.Publishing
{
    public interface IEventPublisherFactory
    {
        IEventPublisher<TPublisher> Create<TPublisher>();
    }
}
