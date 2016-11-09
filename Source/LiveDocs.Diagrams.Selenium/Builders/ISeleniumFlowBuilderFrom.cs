namespace LiveDocs.Diagrams.Selenium.Builders
{
    using LiveDocs.Diagrams.Graph.Executable.Models;
    
    public interface ISeleniumFlowBuilderFrom
    {
        ISeleniumFlowBuilderTo To(IState state);

        ISeleniumFlowBuilderTo To<TState>() where TState : class, IState;
    }
}