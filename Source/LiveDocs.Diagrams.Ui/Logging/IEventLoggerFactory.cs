namespace LiveDocs.Diagrams.Ui.Logging
{
    public interface IEventLoggerFactory
    {
        IEventLogger<TLogger> Create<TLogger>();
    }
}