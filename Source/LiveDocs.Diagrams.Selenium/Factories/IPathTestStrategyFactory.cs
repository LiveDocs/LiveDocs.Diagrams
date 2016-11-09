namespace LiveDocs.Diagrams.Selenium.Factories
{
    using LiveDocs.Diagrams.Graph.Executable.Models;
    using LiveDocs.Diagrams.Graph.Executable.Services;
    
    using OpenQA.Selenium;

    // TODO: make generic
    public interface IPathTestStrategyFactory
    {
        IPathTestStrategy<IState, ITransition> Create(IWebDriver driver);
    }
}