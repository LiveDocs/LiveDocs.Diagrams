namespace LiveDocs.Diagrams.Selenium.Commands
{
    using System;

    using LiveDocs.Diagrams.Graph.Executable.Commands;    

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// Waits for the specified time to elaspse.
    /// </summary>
    public class WaitTimeCommand : ICommand
    {
        /// <summary>
        /// The driver
        /// </summary>
        private readonly IWebDriver driver;

        private readonly double timeWaitSeconds;

        /// <summary>
        /// Initialises a new instance of the <see cref="WaitTimeCommand"/> class.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="timeWaitSeconds">The time wait seconds.</param>
        public WaitTimeCommand(IWebDriver driver, double timeWaitSeconds)
        {
            this.driver = driver;
            this.timeWaitSeconds = timeWaitSeconds;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name => $"Waiting for {this.timeWaitSeconds} seconds";

        /// <summary>
        /// Executes this instance.
        /// </summary>
        public void Execute()
        {
            try
            {                
                var webWaitDriver = new WebDriverWait(this.driver, TimeSpan.FromSeconds(this.timeWaitSeconds));
                webWaitDriver.Until(d => false);
            }            
            catch (WebDriverTimeoutException)
            {
                // Timeout exception is expected.
            }
        }
    }
}