namespace LiveDocs.Diagrams.Selenium.Queries
{
    using System;
    using System.Text.RegularExpressions;

    using LiveDocs.Diagrams.Graph.Executable.Queries;    

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public class UriQuery : IQuery
    {
        private readonly IWebDriver driver;

        private readonly string uriRegex;

        private readonly int timeoutSeconds;

        public UriQuery(IWebDriver driver, string uriRegex, int timeoutSeconds)
        {
            this.driver = driver;
            this.uriRegex = uriRegex;
            this.timeoutSeconds = timeoutSeconds;
        }

        public string Name => $"Testing that current browser URI matches expected URI regex '{this.uriRegex}'";

        public bool Execute()
        {
            var webWaitDriver = new WebDriverWait(this.driver, TimeSpan.FromSeconds(this.timeoutSeconds));
            return webWaitDriver.Until(d => Regex.IsMatch(this.driver.Url, this.uriRegex, RegexOptions.IgnoreCase));
        }
    }
}