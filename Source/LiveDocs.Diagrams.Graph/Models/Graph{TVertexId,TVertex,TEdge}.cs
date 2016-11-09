namespace LiveDocs.Diagrams.Graph.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using QuickGraph;

    public class Graph<TVertexId, TVertex, TEdge>
        where TVertex : class, IVertex<TVertexId>
        where TEdge : class, IEdge<TVertex>
    {
        private readonly AdjacencyGraph<TVertex, QuickGraphEdge<TVertexId, TVertex, TEdge>> graph;

        public Graph()
        {             
            this.graph = new AdjacencyGraph<TVertex, QuickGraphEdge<TVertexId, TVertex, TEdge>>(allowParallelEdges: false);
        }

        public Graph(IEnumerable<TEdge> edges)
        {
            if (edges == null)
            {
                throw new ArgumentNullException(nameof(edges));
            }

            this.graph = new AdjacencyGraph<TVertex, QuickGraphEdge<TVertexId, TVertex, TEdge>>(allowParallelEdges: false);
            this.graph.AddVerticesAndEdgeRange(edges.Select(e => new QuickGraphEdge<TVertexId, TVertex, TEdge>(e)));
        }

        public void AddVertex(TVertex vertex)
        {
            this.graph.AddVertex(vertex);
        }

        public void AddEdge(TEdge edge)
        {
            this.graph.AddEdge(new QuickGraphEdge<TVertexId, TVertex, TEdge>(edge));
        }

        public void AddVerticesAndEdge(TEdge edge)
        {
            this.graph.AddVerticesAndEdge(new QuickGraphEdge<TVertexId, TVertex, TEdge>(edge));
        }

        public IEnumerable<TEdge> OutEdges(TVertex vertex)
        {
            return this.graph.OutEdges(vertex).Select(e => e.Edge);
        }

        public IEnumerable<TVertex> Vertices => this.graph.Vertices;

        public IEnumerable<TEdge> Edges => this.graph.Edges.Select(e => e.Edge);
    }
}