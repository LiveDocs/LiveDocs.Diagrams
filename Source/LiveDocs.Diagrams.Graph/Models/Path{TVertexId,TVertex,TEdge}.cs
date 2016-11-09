namespace LiveDocs.Diagrams.Graph.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Path<TVertexId, TVertex, TEdge>
        where TVertex : IVertex<TVertexId>
        where TEdge : IEdge<TVertex>
    {
        private IEnumerable<TEdge> edges;

        public Path(IEnumerable<TEdge> edges)
        {
            this.edges = edges;
        }

        public IEnumerable<TEdge> Edges => this.edges ?? (this.edges = Enumerable.Empty<TEdge>());

        public override string ToString()
        {
            if (!this.Edges.Any())
            {
                return string.Empty;
            }

            var sb = new StringBuilder();

            foreach (var edge in this.edges)
            {
                var targetNamed = edge.Target as INamed;
                var targetName = targetNamed == null ? edge.Target.Id.ToString() : targetNamed.Name;

                if (edge.Id == this.edges.First().Id)
                {
                    var sourceNamed = edge.Source as INamed;
                    var sourceName = sourceNamed == null ? edge.Source.Id.ToString() : sourceNamed.Name;

                    sb.Append($"{sourceName} -> {targetName}");
                    continue;
                }

                sb.Append($" -> {targetName}");
            }

            return sb.ToString();
        }
    }
}