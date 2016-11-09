namespace LiveDocs.Diagrams.Selenium.Factories
{
    using OpenQA.Selenium;

    public interface IWebDriverFactory
    {
        IWebDriver Create();
    }
}