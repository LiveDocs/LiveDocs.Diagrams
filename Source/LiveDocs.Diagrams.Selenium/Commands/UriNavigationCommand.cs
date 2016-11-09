namespace LiveDocs.Diagrams.Selenium.Commands
{
    using System;

    using LiveDocs.Diagrams.Graph.Executable.Commands;    

    using OpenQA.Selenium;

    public class UriNavigationCommand : ICommand
    {
        private IWebDriver driver;

        private readonly Uri uri;

        public UriNavigationCommand(IWebDriver driver, Uri uri)
        {
            this.driver = driver;
            this.uri = uri;
        }

        public string Name => $"Navigating to uri {this.uri}";

        public void Execute()
        {            
            this.driver.Navigate().GoToUrl(this.uri);
        }
    }
}