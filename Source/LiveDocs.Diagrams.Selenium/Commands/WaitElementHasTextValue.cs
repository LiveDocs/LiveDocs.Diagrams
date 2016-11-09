namespace LiveDocs.Diagrams.Selenium.Commands
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    using LiveDocs.Diagrams.Graph.Executable.Commands;
    using LiveDocs.Diagrams.Selenium.Helpers;    

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using OpenQA.Selenium.Support.UI;

    public class WaitElementHasTextValue<TPage> : ICommand
    {
        private readonly IWebDriver driver;

        private readonly int timeoutSeconds;

        private readonly IWebElement webElement;

        private readonly string elementDetails;

        private readonly string value;

        public WaitElementHasTextValue(IWebDriver driver, Expression<Func<TPage, IWebElement>> propertySelector, string value, int timeoutSeconds)
        {
            this.driver = driver;
            this.timeoutSeconds = timeoutSeconds;

            var page = PageFactory.InitElements<TPage>(this.driver);

            this.value = value;
            
            this.elementDetails = PropertyHelper.GetElementDetails(propertySelector);
            this.webElement = propertySelector.Compile()(page);
        }

        public string Name => $"Waiting for element {this.elementDetails} to have value {this.value}";

        public void Execute()
        {
            var webWaitDriver = new WebDriverWait(this.driver, TimeSpan.FromSeconds(this.timeoutSeconds));
            webWaitDriver.Until(
                d =>
                    {
                        try
                        {
                            return this.webElement.Text == this.value;
                        }
                        catch (TargetException)
                        {
                            return false;
                        }
                    });
        }
    }
}