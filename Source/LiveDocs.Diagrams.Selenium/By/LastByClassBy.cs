namespace LiveDocs.Diagrams.Selenium.By
{
    using System;
    using System.Linq;

    using OpenQA.Selenium;

    public class LastByClassBy : By
    {
        private readonly string className;

        public LastByClassBy(string className)
        {
            if (string.IsNullOrWhiteSpace(className))
            {
                throw new ArgumentNullException(nameof(className));
            }

            this.className = className;            
        }

        public override IWebElement FindElement(ISearchContext context)
        {
            return context.FindElements(By.ClassName(this.className)).LastOrDefault();
        }
    }
}