namespace LiveDocs.Diagrams.Selenium.Models
{
    using System;

    using LiveDocs.Diagrams.Graph.Executable.Commands;    

    using OpenQA.Selenium;

    public abstract class SeleniumAction : ISeleniumCommandable
    {
        protected SeleniumAction(string name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
        }

        public Guid Id { get; }

        public string Name { get; }

        public abstract ICommand GetCommand(Uri hostUri, IWebDriver driver);        
    }
}