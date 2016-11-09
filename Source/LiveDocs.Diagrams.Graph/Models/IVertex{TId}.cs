namespace LiveDocs.Diagrams.Graph.Models
{
    public interface IVertex<out TId>
    {
        TId Id { get; }
    }
}