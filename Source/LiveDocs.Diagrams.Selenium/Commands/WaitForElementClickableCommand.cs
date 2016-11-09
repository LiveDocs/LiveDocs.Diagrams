namespace LiveDocs.Diagrams.Selenium.Commands
{
    using System;
    using System.Linq.Expressions;

    using LiveDocs.Diagrams.Graph.Executable.Commands;
    using LiveDocs.Diagrams.Selenium.Helpers;    

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using OpenQA.Selenium.Support.UI;

    public class WaitForElementClickableCommand<TPage> : ICommand
    {
        private readonly IWebDriver driver;        

        private readonly int timeoutSeconds;

        private readonly IWebElement webElement;

        private readonly string elementDetails;

        private readonly Expression<Func<TPage, IWebElement>> propertySelector;

        public WaitForElementClickableCommand(IWebDriver driver, Expression<Func<TPage, IWebElement>> propertySelector, int timeoutSeconds)
        {
            this.driver = driver;            
            this.timeoutSeconds = timeoutSeconds;

            var page = PageFactory.InitElements<TPage>(this.driver);

            this.propertySelector = propertySelector;
            this.elementDetails = PropertyHelper.GetElementDetails(propertySelector);
            this.webElement = propertySelector.Compile()(page);
        }

        public string Name => $"Waiting for element {this.elementDetails}";

        public void Execute()
        {                     
            var webWaitDriver = new WebDriverWait(this.driver, TimeSpan.FromSeconds(this.timeoutSeconds));
            webWaitDriver.Until(ExpectedConditions.ElementToBeClickable(this.webElement));
        }
    }
}