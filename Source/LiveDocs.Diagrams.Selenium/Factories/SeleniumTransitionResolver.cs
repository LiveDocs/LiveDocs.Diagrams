namespace LiveDocs.Diagrams.Selenium.Factories
{
    using System;

    using LiveDocs.Diagrams.Graph.Executable.Commands;
    using LiveDocs.Diagrams.Graph.Executable.Models;
    using LiveDocs.Diagrams.Graph.Executable.Queries;
    using LiveDocs.Diagrams.Graph.Executable.Services;
    using LiveDocs.Diagrams.Graph.Models;
    using LiveDocs.Diagrams.Selenium.Models;

    using OpenQA.Selenium;

    public class SeleniumTransitionResolver : ICommandResolver, IQueryResolver
    {
        private readonly Uri hostUri;

        private readonly IWebDriver driver;

        public SeleniumTransitionResolver(Uri hostUri, IWebDriver driver)
        {
            this.hostUri = hostUri;
            this.driver = driver;
        }

        public ICommand GetCommand(IAction action)
        {
            var seleniumAction = action as SeleniumAction;
            return seleniumAction?.GetCommand(this.hostUri, this.driver);
        }

        public IQuery GetQuery(IVertex vertex)
        {
            var seleniumQueryableState = vertex as ISeleniumQueryable;
            return seleniumQueryableState?.GetQuery(this.hostUri, this.driver);
        }
    }
}