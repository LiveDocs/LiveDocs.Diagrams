namespace LiveDocs.Diagrams.Graph.Executable.Logging
{
    using System;
    using System.Collections.Generic;

    using LiveDocs.Diagrams.Graph.Executable.Events;

    public class EventIndentationLogger<TLogger> : IEventLogger<TLogger>
    {
        private readonly LogLevel logLevel;

        private readonly IEventLogger<TLogger> logger;

        private readonly IDictionary<Type, int> eventIndentations;        

        public EventIndentationLogger(LogLevel logLevel, IEventLogger<TLogger> logger, IDictionary<Type, int> eventIndentations)
        {
            if (logLevel == LogLevel.None)
            {
                throw new ArgumentNullException(nameof(logLevel));
            }

            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            if (eventIndentations == null)
            {
                throw new ArgumentNullException(nameof(eventIndentations));
            }

            this.logLevel = logLevel;
            this.logger = logger;
            this.eventIndentations = eventIndentations;
        }

        public void Log<TEvent>(LogLevel logLevel, TEvent @event, Exception exception = null) where TEvent : IEvent
        {
            if (logLevel < this.logLevel)
            {
                return;
            }

            var messageLevel = 0;
            if (this.eventIndentations.ContainsKey(typeof(TEvent)))
            {
                messageLevel = this.eventIndentations[typeof(TEvent)];
            }

            this.logger.Log(logLevel, new EventLevelEvent(@event, messageLevel));
        }
    }
}