namespace LiveDocs.Diagrams.Selenium.BuilderImplementations
{
    using System;

    using LiveDocs.Diagrams.Graph.Executable.Builders;
    using LiveDocs.Diagrams.Graph.Executable.Models;
    using LiveDocs.Diagrams.Graph.Models;
    using LiveDocs.Diagrams.Selenium.Builders;
    using LiveDocs.Diagrams.Selenium.Models;    

    internal class SeleniumFlowBuilderTo : ISeleniumFlowBuilderTo
    {
        private readonly IFlowBuilderTo flowBuilderTo;        

        public SeleniumFlowBuilderTo(IFlowBuilderTo flowBuilderTo)
        {
            this.flowBuilderTo = flowBuilderTo;
        }

        public ISeleniumFlowBuilder Via<TAction>() where TAction : class, IAction, ISeleniumCommandable
        {
            return new SeleniumFlowBuilder(this.flowBuilderTo.Via<TAction>());
        }

        public ISeleniumFlowBuilder Via<TAction>(TAction action) where TAction : class, IAction, ISeleniumCommandable
        {
            return new SeleniumFlowBuilder(this.flowBuilderTo.Via(action));
        }

        public ISeleniumFlowBuilder Via(Func<ISeleniumQueryable, ISeleniumQueryable, ISeleniumCommandable> commandFactory)
        {
            var actionFactory = new Func<IVertex, IVertex, IAction>((from, to) => commandFactory(from as ISeleniumQueryable, to as ISeleniumQueryable));
            return new SeleniumFlowBuilder(this.flowBuilderTo.Via(actionFactory));
        }
    }
}