namespace LiveDocs.Diagrams.Selenium.Commands
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using LiveDocs.Diagrams.Graph.Executable.Commands;
    using LiveDocs.Diagrams.Selenium.Helpers;    

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class SelectDropdownCommand<TPage> : ICommand
    {
        private readonly IWebElement selectElement;

        private readonly string value;

        private readonly string elementDetails;

        private readonly bool useText;

        public SelectDropdownCommand(IWebDriver driver, Expression<Func<TPage, IWebElement>> propertySelector, string value, bool useText)
        {
            this.value = value;
            var page = PageFactory.InitElements<TPage>(driver);
            this.useText = useText;

            this.elementDetails = PropertyHelper.GetElementDetails(propertySelector);
            this.selectElement = propertySelector.Compile()(page);
        }

        public string Name => $"Selecting value {this.value} on dropdown {this.elementDetails}";

        public void Execute()
        {            
            var optionElement = this.useText
                ? this.selectElement.FindElements(By.TagName("option")).FirstOrDefault(o => o.Text == this.value)
                : this.selectElement.FindElement(By.CssSelector($"option[value='{this.value}']"));

            if (optionElement == null)
            {
                throw new InvalidOperationException(
                          $"The select element {this.elementDetails} does not have option with value '{this.value}'");
            }

            if (optionElement.Selected)
            {
                return;
            }

            optionElement.Click();
        }
    }
}