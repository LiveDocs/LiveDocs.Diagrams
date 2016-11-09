namespace LiveDocs.Diagrams.Selenium.Commands
{
    using System;
    using System.Linq.Expressions;

    using LiveDocs.Diagrams.Graph.Executable.Commands;
    using LiveDocs.Diagrams.Selenium.Helpers;
    
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class EnterTextCommand<TPage> : ICommand
        where TPage : class
    {                
        private readonly IWebElement webElement;

        private readonly string value;

        private readonly string elementDetails;

        public EnterTextCommand(IWebDriver driver, Expression<Func<TPage, IWebElement>> propertySelector, string value)
        {            
            this.value = value;
            var page = PageFactory.InitElements<TPage>(driver);

            this.elementDetails = PropertyHelper.GetElementDetails(propertySelector);
            this.webElement = propertySelector.Compile()(page);
        }

        public string Name => $"Entering text {this.value} on element {this.elementDetails}";

        public void Execute()
        {
            if (this.webElement == null)
            {
                throw new InvalidOperationException(
                    $"Attempting to enter text '{this.value}' on a page element not found.");
            }

            this.webElement.SendKeys(this.value);
        }
    }
}