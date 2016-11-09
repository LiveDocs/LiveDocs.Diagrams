namespace LiveDocs.Diagrams.Ui.Services
{
    using LiveDocs.Diagrams.Graph.Model;
    using LiveDocs.Diagrams.Ui.Queries;

    public interface IQueryResolver
    {
        IQuery GetQuery(IVertex vertex);
    }
}