namespace LiveDocs.Diagrams.Selenium.BuilderImplementations
{
    using System;

    using LiveDocs.Diagrams.Graph.Executable.Builders;
    using LiveDocs.Diagrams.Graph.Executable.Models;
    using LiveDocs.Diagrams.Graph.Models;
    using LiveDocs.Diagrams.Selenium.Builders;
    using LiveDocs.Diagrams.Selenium.Models;

    internal class SeleniumStartViaBuilder : ISeleniumStartViaBuilder
    {
        private readonly IStartViaBuilder startViaBuilder;        

        public SeleniumStartViaBuilder(IStartViaBuilder startViaBuilder)
        {
            this.startViaBuilder = startViaBuilder;
        }

        public ISeleniumFlowBuilder Via<TAction>() where TAction : class, ISeleniumCommandable
        {
            return new SeleniumFlowBuilder(this.startViaBuilder.Via<TAction>());
        }

        public ISeleniumFlowBuilder Via(ISeleniumCommandable action)
        {
            return new SeleniumFlowBuilder(this.startViaBuilder.Via(action));
        }

        public ISeleniumFlowBuilder Via(Func<ISeleniumQueryable, ISeleniumQueryable, ISeleniumCommandable> commandFactory)
        {
            var actionFactory = new Func<IVertex, IVertex, IAction>((from, to) => commandFactory(from as ISeleniumQueryable, to as ISeleniumQueryable));
            return new SeleniumFlowBuilder(this.startViaBuilder.Via(actionFactory));
        }
    }
}