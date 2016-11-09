namespace LiveDocs.Diagrams.Ui.Builders
{
    using System;

    using LiveDocs.Diagrams.Ui.Models;

    public interface IFlowBuilderTo
    {
        IFlowBuilder Via(IAction action);

        IFlowBuilder Via(Func<IState, IState, IAction> actionFactory);

        IFlowBuilder Via<TAction>() where TAction : class, IAction;
    }
}