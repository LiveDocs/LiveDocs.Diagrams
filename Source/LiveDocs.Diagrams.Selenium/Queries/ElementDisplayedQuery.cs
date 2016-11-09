namespace LiveDocs.Diagrams.Selenium.Queries
{
    using System;
    using System.Linq.Expressions;

    using LiveDocs.Diagrams.Graph.Executable.Queries;
    using LiveDocs.Diagrams.Selenium.Helpers;    

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using OpenQA.Selenium.Support.UI;

    public class ElementDisplayedQuery<TPage> : IQuery
    {
        private readonly int timeoutSeconds;

        private readonly IWebElement webElement;

        private readonly string elementDetails;

        private readonly IWebDriver driver;

        public ElementDisplayedQuery(IWebDriver driver, Expression<Func<TPage, IWebElement>> propertySelector, int timeoutSeconds)
        {
            this.driver = driver;
            this.timeoutSeconds = timeoutSeconds;
            this.elementDetails = PropertyHelper.GetElementDetails(propertySelector);

            var page = PageFactory.InitElements<TPage>(driver);
            this.webElement = propertySelector.Compile()(page);
        }

        public string Name => $"Testing that element {this.elementDetails} is displayed";

        public bool Execute()
        {
            var webWaitDriver = new WebDriverWait(this.driver, TimeSpan.FromSeconds(this.timeoutSeconds));
            return webWaitDriver.Until(d => this.webElement.Displayed);
        }
    }
}