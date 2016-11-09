namespace LiveDocs.Diagrams.Graph.Executable.Logging
{
    using System;
    using System.Collections.Generic;

    using LiveDocs.Diagrams.Graph.Executable.Events;
    using LiveDocs.Diagrams.Graph.Executable.Publishing;

    public class LoggingEventPublisher<TPublisher> : IEventPublisher<TPublisher>
    {
        private readonly IEventLogger<TPublisher> logger;

        private readonly IDictionary<Type, LogLevel> eventLogLevels;

        public LoggingEventPublisher(IEventLoggerFactory loggerFactory)
        {
            if (loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            this.logger = loggerFactory.Create<TPublisher>();

            this.eventLogLevels = new Dictionary<Type, LogLevel>
            {
                { typeof(PathResolutionCompleteEvent), LogLevel.Debug },
                { typeof(PathExecutionEvent), LogLevel.Debug },
                { typeof(ActionExecutionEvent), LogLevel.Debug },
                { typeof(CommandExecutionEvent), LogLevel.Trace },
                { typeof(QueryExecutionEvent), LogLevel.Trace }
            };
        }

        public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var logLevel = this.eventLogLevels.ContainsKey(typeof(TEvent))
                ? this.eventLogLevels[typeof(TEvent)]
                : LogLevel.Info;

            this.logger.Log(logLevel, @event);
        }
    }
}