namespace LiveDocs.Diagrams.Graph.Executable.Logging
{
    public interface IEventLoggerFactory
    {
        IEventLogger<TLogger> Create<TLogger>();
    }
}