namespace LiveDocs.Diagrams.Ui.Logging
{
    using LiveDocs.Diagrams.Ui.Publishing;

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