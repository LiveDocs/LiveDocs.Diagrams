namespace LiveDocs.Diagrams.Selenium.By
{
    using System;
    using System.Linq;

    using OpenQA.Selenium;

    public class FirstByClassBy : By
    {
        private readonly string className;

        public FirstByClassBy(string className)
        {
            if (string.IsNullOrWhiteSpace(className))
            {
                throw new ArgumentNullException(nameof(className));
            }

            this.className = className;         
        }

        public override IWebElement FindElement(ISearchContext context)
        {
            var element = context.FindElements(By.ClassName(this.className)).FirstOrDefault();
            return element;
        }        
    }
}