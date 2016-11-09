namespace LiveDocs.Diagrams.Graph.Executable.Logging
{
    using LiveDocs.Diagrams.Graph.Executable.Publishing;

    public class LoggingEventPublisherFactory : IEventPublisherFactory
    {
        private readonly IEventLoggerFactory loggerFactory;

        public LoggingEventPublisherFactory(IEventLoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
        }

        public IEventPublisher<TPublisher> Create<TPublisher>()
        {
            return new LoggingEventPublisher<TPublisher>(this.loggerFactory);
        }
    }
}