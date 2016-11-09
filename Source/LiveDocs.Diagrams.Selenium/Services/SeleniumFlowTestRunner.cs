namespace LiveDocs.Diagrams.Selenium.Services
{
    using System;
    using System.Linq;

    using LiveDocs.Diagrams.Graph.Executable.Events;
    using LiveDocs.Diagrams.Graph.Executable.Models;
    using LiveDocs.Diagrams.Graph.Executable.Publishing;
    using LiveDocs.Diagrams.Graph.Services;
    using LiveDocs.Diagrams.Selenium.Factories;

    using OpenQA.Selenium;

    public class SeleniumFlowTestRunner
    {
        private readonly IWebDriverFactory webDriverFactory;

        private readonly IPathResolverStrategy<IState, ITransition> pathResolverStrategy;

        private readonly IPathTestStrategyFactory pathTestStrategyFactory;        

        private readonly IEventPublisherFactory publisherFactory;

        private readonly IEventPublisher<SeleniumFlowTestRunner> publisher;

        public SeleniumFlowTestRunner(
            IWebDriverFactory webDriverFactory,
            IPathResolverStrategy<IState, ITransition> pathResolverStrategy,
            IPathTestStrategyFactory pathTestStrategyFactory,
            IEventPublisherFactory publisherFactory)
        {
            this.webDriverFactory = webDriverFactory;
            this.pathResolverStrategy = pathResolverStrategy;
            this.pathTestStrategyFactory = pathTestStrategyFactory;            
            this.publisherFactory = publisherFactory;
            this.publisher = publisherFactory.Create<SeleniumFlowTestRunner>();
        }

        public void Run(Flow flow, Action<bool, string> assertion, bool closeDriverAfterEachPathExecution = false)
        {
            if (flow == null)
            {
                throw new ArgumentNullException(nameof(flow));
            }

            if (assertion == null)
            {
                throw new ArgumentNullException(nameof(assertion));
            }

            var graph = flow.ToGraph();
            var startScreen = graph.Vertices.FirstOrDefault(v => v.Id == StartState.Identifier);
            if (startScreen == null)
            {
                throw new InvalidOperationException("No start screen specified.");
            }

            var paths = this.pathResolverStrategy.GetPaths(graph, startScreen).ToList();
            this.publisher.Publish(new PathResolutionCompleteEvent(paths));

            IWebDriver driver = null;
            try
            {
                if (!closeDriverAfterEachPathExecution)
                {
                    driver = this.webDriverFactory.Create();
                }

                for (var i = 0; i < paths.Count; i++)
                {
                    var path = paths[i];

                    if (closeDriverAfterEachPathExecution)
                    {
                        driver = this.webDriverFactory.Create();
                    }

                    this.publisher.Publish(new PathExecutionEvent(path, i + 1, paths.Count));

                    var pathTestStrategy = this.pathTestStrategyFactory.Create(driver);
                    var test = pathTestStrategy.GetTest(path, this.publisherFactory);

                    bool result;
                    try
                    {
                        result = test.Execute();
                        assertion(result, test.Name);
                    }
                    catch (Exception exception)
                    {
                        assertion(false, $"{test.Name} {exception}");
                        // TODO: throw on first failure option                    
                    }                   

                    if (closeDriverAfterEachPathExecution)
                    {
                        driver?.Quit();
                    }
                }
            }
            finally
            {
                if (!closeDriverAfterEachPathExecution)
                {
                    driver?.Quit();
                }
            }
        }
    }
}