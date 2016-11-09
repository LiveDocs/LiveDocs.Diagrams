namespace LiveDocs.Diagrams.Ui.Logging
{
    using System;

    using LiveDocs.Diagrams.Ui.Events;

    public interface IEventLogger<TLogger>
    {
        void Log<TEvent>(LogLevel logLevel, TEvent @event, Exception exception = null) where TEvent : IEvent;
    }
}