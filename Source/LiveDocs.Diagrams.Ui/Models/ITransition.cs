namespace LiveDocs.Diagrams.Ui.Models
{
    using LiveDocs.Diagrams.Graph.Model;

    public interface ITransition : IEdge<IState>
    {
        IAction Action { get; }
    }
}