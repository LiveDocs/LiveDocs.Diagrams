namespace LiveDocs.Diagrams.Ui.Models
{
    using System;

    using LiveDocs.Diagrams.Graph.Model;

    public interface IAction : INamed
    {
        Guid Id { get; }
    }
}