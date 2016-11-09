namespace LiveDocs.Diagrams.Graph.Executable.Models
{
    using System.Collections.Generic;

    public interface ISequentialDecision<TSelection> : IDecision
    {
        IEnumerable<TSelection> Selections { get; }
    }
}