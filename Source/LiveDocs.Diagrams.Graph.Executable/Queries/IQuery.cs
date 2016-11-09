namespace LiveDocs.Diagrams.Graph.Executable.Queries
{
    public interface IQuery
    {
        string Name { get; }

        bool Execute();
    }
}