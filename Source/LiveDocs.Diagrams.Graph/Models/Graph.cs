namespace LiveDocs.Diagrams.Graph.Models
{
    using System;
    using System.Collections.Generic;

    public class Graph<TVertex, TEdge> : Graph<Guid, TVertex, TEdge>
        where TVertex : class, IVertex<Guid>
        where TEdge : class, IEdge<TVertex>
    {
        public Graph()
        {
        }

        public Graph(IEnumerable<TEdge> edges) : base(edges)
        {            
        }
    }
}
