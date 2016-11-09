namespace LiveDocs.Diagrams.Ui.Builders
{    
    using LiveDocs.Diagrams.Ui.Models;

    public interface IFlowBuilderFrom
    {
        IFlowBuilderTo To(IState targetState);

        IFlowBuilderTo To<TState>() where TState : class, IState;
    }
}