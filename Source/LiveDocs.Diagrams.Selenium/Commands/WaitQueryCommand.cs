namespace LiveDocs.Diagrams.Selenium.Commands
{
    using System;

    using LiveDocs.Diagrams.Graph.Executable.Commands;
    using LiveDocs.Diagrams.Graph.Executable.Queries;    

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public class WaitQueryCommand : ICommand
    {
        private readonly IWebDriver driver;

        private readonly IQuery query;

        private readonly int timeoutSeconds;

        public WaitQueryCommand(IWebDriver driver, IQuery query, int timeoutSeconds)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(nameof(driver));
            }

            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            this.driver = driver;
            this.query = query;
            this.timeoutSeconds = timeoutSeconds;
        }

        public string Name => $"Waiting for query '{this.query.Name}' to succeed";

        public void Execute()
        {
            var webWaitDriver = new WebDriverWait(this.driver, TimeSpan.FromSeconds(this.timeoutSeconds));
            webWaitDriver.Until(d => this.query.Execute());
        }
    }
}