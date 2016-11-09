namespace LiveDocs.Diagrams.Graph.Models
{
    internal class QuickGraphEdge<TVertexId, TVertex, TEdge> : QuickGraph.Edge<TVertex>
        where TVertex : class, IVertex<TVertexId>
        where TEdge : class, IEdge<TVertex>
    {
        public QuickGraphEdge(TEdge edge) : base(edge.Source, edge.Target)
        {
            this.Edge = edge;
        }

        public TEdge Edge { get; }
    }
}