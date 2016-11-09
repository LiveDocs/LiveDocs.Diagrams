namespace LiveDocs.Diagrams.Ui.Queries
{
    public interface IQuery
    {
        string Name { get; }

        bool Execute();
    }
}