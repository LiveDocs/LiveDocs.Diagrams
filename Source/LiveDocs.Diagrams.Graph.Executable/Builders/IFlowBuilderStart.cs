namespace LiveDocs.Diagrams.Graph.Executable.Builders
{
    using LiveDocs.Diagrams.Graph.Executable.Models;

    public interface IFlowBuilderStart
    {
        IFlowBuilderFrom From<TState>() where TState : class, IState;

        IFlowBuilderFrom From(IState state);

        Flow Build();
    }
}