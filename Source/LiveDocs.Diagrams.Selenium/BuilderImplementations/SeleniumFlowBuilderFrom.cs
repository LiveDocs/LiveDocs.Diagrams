namespace LiveDocs.Diagrams.Selenium.BuilderImplementations
{
    using LiveDocs.Diagrams.Graph.Executable.Builders;
    using LiveDocs.Diagrams.Graph.Executable.Models;
    using LiveDocs.Diagrams.Selenium.Builders;

    internal class SeleniumFlowBuilderFrom : ISeleniumFlowBuilderFrom
    {
        private readonly IFlowBuilderFrom flowBuilderFrom;        

        public SeleniumFlowBuilderFrom(IFlowBuilderFrom flowBuilderFrom)
        {
            this.flowBuilderFrom = flowBuilderFrom;
        }

        public ISeleniumFlowBuilderTo To(IState state)
        {
            return new SeleniumFlowBuilderTo(this.flowBuilderFrom.To(state));
        }

        public ISeleniumFlowBuilderTo To<TState>() where TState : class, IState
        {
            return new SeleniumFlowBuilderTo(this.flowBuilderFrom.To<TState>());
        }
    }
}