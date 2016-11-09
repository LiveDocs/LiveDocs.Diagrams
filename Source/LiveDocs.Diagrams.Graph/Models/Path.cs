namespace LiveDocs.Diagrams.Graph.Models
{
    using System;
    using System.Collections.Generic;

    public class Path<TVertex, TEdge> : Path<Guid, TVertex, TEdge>
        where TVertex : IVertex<Guid>
        where TEdge : IEdge<TVertex>
    {
        public Path(IEnumerable<TEdge> edges) : base(edges)
        {
        }
    }
}