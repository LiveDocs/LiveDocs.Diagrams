namespace LiveDocs.Diagrams.Graph.Executable.Publishing
{
    public interface IEventPublisherFactory
    {
        IEventPublisher<TPublisher> Create<TPublisher>();
    }
}
