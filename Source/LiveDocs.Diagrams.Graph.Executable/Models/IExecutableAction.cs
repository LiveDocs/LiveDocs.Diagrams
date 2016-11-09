namespace LiveDocs.Diagrams.Graph.Executable.Models
{
    using LiveDocs.Diagrams.Graph.Executable.Commands;

    public interface IExecutableAction : IAction
    {
        ICommand Command { get; }
    }
}