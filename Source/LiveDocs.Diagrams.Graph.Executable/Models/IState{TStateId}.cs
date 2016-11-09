namespace LiveDocs.Diagrams.Graph.Executable.Models
{
    using LiveDocs.Diagrams.Graph.Models;

    public interface IState<out TStateId> : IVertex<TStateId>, INamed
    {        
    }
}