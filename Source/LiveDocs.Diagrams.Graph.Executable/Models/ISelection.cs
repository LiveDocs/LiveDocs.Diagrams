namespace LiveDocs.Diagrams.Graph.Executable.Models
{
    using System;

    using LiveDocs.Diagrams.Graph.Models;

    public interface ISelection : INamed
    {
        Guid Id { get; }
    }
}