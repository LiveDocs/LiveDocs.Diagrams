namespace LiveDocs.Diagrams.Selenium.Commands
{
    using System;
    using System.Linq.Expressions;

    using LiveDocs.Diagrams.Graph.Executable.Commands;
    using LiveDocs.Diagrams.Selenium.Helpers;    

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class SelectCommand<TPage> : ICommand
    {
        private readonly IWebDriver driver;

        private readonly IWebElement webElement;

        private readonly string elementDetails;        

        public SelectCommand(IWebDriver driver, Expression<Func<TPage, IWebElement>> propertySelector)
        {
            this.driver = driver;
            var page = PageFactory.InitElements<TPage>(driver);

            this.elementDetails = PropertyHelper.GetElementDetails(propertySelector);
            this.webElement = propertySelector.Compile()(page);
        }

        public string Name => $"Selecting element {this.elementDetails}";

        public void Execute()
        {
            if (this.webElement.Selected)
            {
                return;
            }

            this.webElement.Click();
        }
    }
}