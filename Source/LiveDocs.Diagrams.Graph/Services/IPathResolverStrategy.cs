namespace LiveDocs.Diagrams.Graph.Services
{
    using System;
    using System.Collections.Generic;

    using LiveDocs.Diagrams.Graph.Models;

    public interface IPathResolverStrategy<TVertex, TEdge>
        where TVertex : class, IVertex<Guid>
        where TEdge : class, IEdge<TVertex>
    {
        IEnumerable<Path<Guid, TVertex, TEdge>> GetPaths(
            Graph<Guid, TVertex, TEdge> graph,
            TVertex startState);
    }
}