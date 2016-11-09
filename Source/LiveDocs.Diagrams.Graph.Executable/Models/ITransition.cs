namespace LiveDocs.Diagrams.Graph.Executable.Models
{
    using LiveDocs.Diagrams.Graph.Models;

    public interface ITransition : IEdge<IState>
    {
        IAction Action { get; }
    }
}