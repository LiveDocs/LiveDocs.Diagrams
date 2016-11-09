namespace LiveDocs.Diagrams.Selenium.Models
{
    using System;

    using LiveDocs.Diagrams.Graph.Executable.Commands;
    using LiveDocs.Diagrams.Graph.Executable.Models;    

    using OpenQA.Selenium;

    public interface ISeleniumCommandable : IAction
    {
        ICommand GetCommand(Uri hostUri, IWebDriver driver);
    }
}