namespace LiveDocs.Diagrams.Selenium.Factories
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    public class ChromeWebDriverFactory : IWebDriverFactory
    {
        private readonly string path;

        public ChromeWebDriverFactory(string path)
        {
            this.path = path;
        }

        public IWebDriver Create()
        {
            // Disables ignore SSL certificate errors warning from Chrome
            // Adapted from http://stackoverflow.com/a/23861240/248164                        
            var options = new ChromeOptions();
            options.AddArguments("test-type");

            return new ChromeDriver(this.path, options);
        }
    }
}