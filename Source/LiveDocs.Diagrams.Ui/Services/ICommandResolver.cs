namespace LiveDocs.Diagrams.Ui.Services
{
    using LiveDocs.Diagrams.Ui.Commands;
    using LiveDocs.Diagrams.Ui.Models;

    public interface ICommandResolver
    {
        ICommand GetCommand(IAction action);
    }
}