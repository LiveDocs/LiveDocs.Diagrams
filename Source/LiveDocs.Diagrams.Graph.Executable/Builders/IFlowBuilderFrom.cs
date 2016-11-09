namespace LiveDocs.Diagrams.Graph.Executable.Builders
{
    using LiveDocs.Diagrams.Graph.Executable.Models;

    public interface IFlowBuilderFrom
    {
        IFlowBuilderTo To(IState targetState);

        IFlowBuilderTo To<TState>() where TState : class, IState;
    }
}