namespace LiveDocs.Diagrams.Graph.Services
{
    using System;

    using LiveDocs.Diagrams.Graph.Models;

    public interface IGraphFilterStrategy<TVertex, TEdge>
        where TVertex : class, IVertex<Guid>
        where TEdge : class, IEdge<TVertex>
    {
        Graph<Guid, TVertex, TEdge> Filter(Graph<Guid, TVertex, TEdge> graph);
    }
}