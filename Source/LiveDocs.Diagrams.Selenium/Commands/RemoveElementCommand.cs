namespace LiveDocs.Diagrams.Selenium.Commands
{
    using System;
    using System.Linq.Expressions;

    using LiveDocs.Diagrams.Graph.Executable.Commands;
    using LiveDocs.Diagrams.Selenium.Helpers;    

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class RemoveElementCommand<TPage> : ICommand
    {
        private readonly IWebDriver driver;

        private readonly IWebElement webElement;

        private readonly string elementDetails;        

        public RemoveElementCommand(IWebDriver driver, Expression<Func<TPage, IWebElement>> propertySelector)
        {
            this.driver = driver;
            var page = PageFactory.InitElements<TPage>(driver);
            this.elementDetails = PropertyHelper.GetElementDetails(propertySelector);
            this.webElement = propertySelector.Compile()(page);
        }

        public string Name => $"Removing the element {this.elementDetails}";

        public void Execute()
        {
            var javascriptExecutor = (IJavaScriptExecutor)this.driver;
            if (javascriptExecutor == null)
            {
                throw new InvalidOperationException("Cannot create javascript executor");
            }

            var className = this.webElement.GetAttribute("class");
            javascriptExecutor.ExecuteScript($"return document.getElementsByClassName('{className}')[0].remove();");
        }
    }
}