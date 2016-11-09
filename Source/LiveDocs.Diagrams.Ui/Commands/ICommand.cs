namespace LiveDocs.Diagrams.Ui.Commands
{
    public interface ICommand
    {
        string Name { get; }    

        void Execute();
    }
}