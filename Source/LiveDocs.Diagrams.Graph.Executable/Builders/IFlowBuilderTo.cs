namespace LiveDocs.Diagrams.Graph.Executable.Builders
{
    using System;

    using LiveDocs.Diagrams.Graph.Executable.Models;

    public interface IFlowBuilderTo
    {
        IFlowBuilderStart Via(IAction action);

        IFlowBuilderStart Via(Func<IState, IState, IAction> actionFactory);

        IFlowBuilderStart Via<TAction>() where TAction : class, IAction;
    }
}