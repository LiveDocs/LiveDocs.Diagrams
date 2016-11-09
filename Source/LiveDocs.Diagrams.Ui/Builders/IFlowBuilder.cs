namespace LiveDocs.Diagrams.Ui.Builders
{    
    using LiveDocs.Diagrams.Ui.Models;

    public interface IFlowBuilder
    {
        IFlowBuilderFrom From<TState>() where TState : class, IState;

        IFlowBuilderFrom From(IState state);

        UiFlow Build();
    }
}