namespace LiveDocs.Diagrams.Graph.UnitTests.Models
{
    using System;

    using LiveDocs.Diagrams.Graph.Models;

    public class TestEdge<TVertex> : IEdge<TVertex>
        where TVertex : IVertex<Guid>
    {
        public TestEdge(TVertex source, TVertex target)
        {
            this.Id = Guid.NewGuid();
            this.Source = source;
            this.Target = target;
        }

        public Guid Id { get; }

        public TVertex Source { get; }

        public TVertex Target { get; }
    }
}