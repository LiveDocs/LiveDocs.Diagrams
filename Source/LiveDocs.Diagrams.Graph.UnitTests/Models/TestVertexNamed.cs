namespace LiveDocs.Diagrams.Graph.UnitTests.Models
{
    using System;

    using LiveDocs.Diagrams.Graph.Models;

    public class TestVertexNamed : IVertex<Guid>, INamed
    {
        public TestVertexNamed(string name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
        }

        public Guid Id { get; }

        public string Name { get; }
    }
}