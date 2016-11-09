namespace LiveDocs.Diagrams.Ui.Logging
{
    using System;
    using System.Collections.Generic;

    using LiveDocs.Diagrams.Ui.Events;

    public class EventLevelLoggerFactory : IEventLoggerFactory
    {
        private readonly LogLevel logLevel;

        private readonly IDictionary<Type, int> eventLevels;

        private readonly IEventLoggerFactory loggerFactory;

        public EventLevelLoggerFactory(LogLevel logLevel, IEventLoggerFactory loggerFactory)
        {
            if (logLevel == LogLevel.None)
            {
                throw new ArgumentNullException(nameof(logLevel));
            }
                     
            if (loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            this.logLevel = logLevel;
            this.loggerFactory = loggerFactory;

            this.eventLevels = new Dictionary<Type, int>
            {
                { typeof(PathExecutionEvent), 0 },
                { typeof(ActionExecutionEvent), 1 },
                { typeof(CommandExecutionEvent), 2 },
                { typeof(QueryExecutionEvent), 1 }
            };
        }

        public IEventLogger<TLogger> Create<TLogger>()
        {
            return new EventIndentationLogger<TLogger>(
                this.logLevel, 
                this.loggerFactory.Create<TLogger>(), 
                this.eventLevels);
        }
    }
}
