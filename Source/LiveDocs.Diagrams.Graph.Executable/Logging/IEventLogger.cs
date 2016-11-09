namespace LiveDocs.Diagrams.Graph.Executable.Logging
{
    using System;

    using LiveDocs.Diagrams.Graph.Executable.Events;

    public interface IEventLogger<TLogger>
    {
        void Log<TEvent>(LogLevel logLevel, TEvent @event, Exception exception = null) where TEvent : IEvent;
    }
}