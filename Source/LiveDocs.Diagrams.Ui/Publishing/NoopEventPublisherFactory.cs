namespace LiveDocs.Diagrams.Ui.Publishing
{
    public class NoopEventPublisherFactory : IEventPublisherFactory
    {
        public IEventPublisher<TLogger> Create<TLogger>()
        {
            return new NoopEventPublisher<TLogger>();
        }
    }
}