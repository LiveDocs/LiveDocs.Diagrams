namespace LiveDocs.Diagrams.Graph.Models
{
    using System;

    public interface IEdge<out TVertex>
    {
        Guid Id { get; }

        TVertex Source { get; }

        TVertex Target { get; }
    }
}
