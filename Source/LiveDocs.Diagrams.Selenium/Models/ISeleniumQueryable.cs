namespace LiveDocs.Diagrams.Selenium.Models
{
    using System;

    using LiveDocs.Diagrams.Graph.Executable.Models;
    using LiveDocs.Diagrams.Graph.Executable.Queries;

    using OpenQA.Selenium;

    public interface ISeleniumQueryable : IState
    {
        IQuery GetQuery(Uri hostUri, IWebDriver driver);
    }
}