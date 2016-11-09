namespace LiveDocs.Diagrams.Graph.Executable.Publishing
{
    public class NoopEventPublisherFactory : IEventPublisherFactory
    {
        public IEventPublisher<TLogger> Create<TLogger>()
        {
            return new NoopEventPublisher<TLogger>();
        }
    }
}