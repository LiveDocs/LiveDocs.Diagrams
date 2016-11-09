namespace LiveDocs.Diagrams.Graph.Executable.Commands
{
    public interface ICommand
    {
        string Name { get; }    

        void Execute();
    }
}