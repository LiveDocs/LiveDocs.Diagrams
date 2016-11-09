namespace LiveDocs.Diagrams.Graph.UnitTests.Models
{
    using System;

    using LiveDocs.Diagrams.Graph.Models;

    public class TestVertex : IVertex<Guid>
    {
        public TestVertex(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; }
    }
}