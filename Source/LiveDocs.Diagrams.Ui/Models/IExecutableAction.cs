namespace LiveDocs.Diagrams.Ui.Models
{
    using LiveDocs.Diagrams.Ui.Commands;

    public interface IExecutableAction : IAction
    {
        ICommand Command { get; }
    }
}