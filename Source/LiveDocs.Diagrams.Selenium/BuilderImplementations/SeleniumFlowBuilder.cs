namespace LiveDocs.Diagrams.Selenium.BuilderImplementations
{
    using LiveDocs.Diagrams.Graph.Executable.Builders;
    using LiveDocs.Diagrams.Graph.Executable.Models;
    using LiveDocs.Diagrams.Selenium.Builders;
    
    internal class SeleniumFlowBuilder : ISeleniumFlowBuilder
    {
        private readonly IFlowBuilderStart flowBuilderStart;

        public SeleniumFlowBuilder(IFlowBuilderStart flowBuilderStart)
        {
            this.flowBuilderStart = flowBuilderStart;
        }

        public ISeleniumFlowBuilderFrom From<TState>() where TState : class, IState
        {            
            return new SeleniumFlowBuilderFrom(this.flowBuilderStart.From<TState>());
        }

        public ISeleniumFlowBuilderFrom From(IState state)
        {
            return new SeleniumFlowBuilderFrom(this.flowBuilderStart.From(state));
        }

        public Flow Build()
        {
            return this.flowBuilderStart.Build();
        }
    }
}