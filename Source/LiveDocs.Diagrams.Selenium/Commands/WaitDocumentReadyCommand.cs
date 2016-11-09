namespace LiveDocs.Diagrams.Selenium.Commands
{
    using System;

    using LiveDocs.Diagrams.Graph.Executable.Commands;    

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public class WaitDocumentReadyCommand : ICommand
    {
        private readonly IWebDriver driver;

        private readonly int timeoutSeconds;

        public string Name => "Waiting for document ready";

        public WaitDocumentReadyCommand(IWebDriver driver, int timeoutSeconds)
        {
            this.driver = driver;
            this.timeoutSeconds = timeoutSeconds;
        }

        // Adapted from http://stackoverflow.com/a/15124562/248164
        public void Execute()
        {
            var webWaitDriver = new WebDriverWait(this.driver, TimeSpan.FromSeconds(this.timeoutSeconds));
            webWaitDriver.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}