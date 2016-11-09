namespace LiveDocs.Diagrams.Graph.Executable.Services
{
    using LiveDocs.Diagrams.Graph.Executable.Commands;
    using LiveDocs.Diagrams.Graph.Executable.Models;

    public interface ICommandResolver
    {
        ICommand GetCommand(IAction action);
    }
}