namespace LiveDocs.Diagrams.Selenium.Models
{
    using System;

    using LiveDocs.Diagrams.Graph.Executable.Queries;    

    using OpenQA.Selenium;

    public abstract class SeleniumScreen : ISeleniumQueryable
    {
        protected SeleniumScreen(IWebDriver driver, string name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
        }

        public Guid Id { get; }

        public string Name { get; }

        public abstract IQuery GetQuery(Uri hostUri, IWebDriver driver);
    }
}