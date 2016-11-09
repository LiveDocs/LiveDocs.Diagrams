namespace LiveDocs.Diagrams.Selenium.Builders
{
    using LiveDocs.Diagrams.Graph.Executable.Models;
    
    public interface ISeleniumFlowBuilder
    {
        ISeleniumFlowBuilderFrom From<TState>() where TState : class, IState;

        ISeleniumFlowBuilderFrom From(IState state);

        Flow Build();
    }
}