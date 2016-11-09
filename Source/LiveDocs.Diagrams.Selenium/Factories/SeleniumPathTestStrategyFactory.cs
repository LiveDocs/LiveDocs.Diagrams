namespace LiveDocs.Diagrams.Selenium.Factories
{
    using System;

    using LiveDocs.Diagrams.Graph.Executable.Models;
    using LiveDocs.Diagrams.Graph.Executable.Services;
    using LiveDocs.Diagrams.Graph.Executable.Strategies;

    using OpenQA.Selenium;

    public class SeleniumPathTestStrategyFactory : IPathTestStrategyFactory
    {
        private readonly Uri hostUri;
        
        public SeleniumPathTestStrategyFactory(Uri hostUri)
        {
            this.hostUri = hostUri;
        }

        public IPathTestStrategy<IState, ITransition> Create(IWebDriver driver)
        {
            var executionResolver = new SeleniumTransitionResolver(this.hostUri, driver);
            return new EndToEndPathStrategy(executionResolver, executionResolver);
        }
    }
}