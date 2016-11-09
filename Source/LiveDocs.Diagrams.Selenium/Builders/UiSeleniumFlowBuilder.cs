namespace LiveDocs.Diagrams.Selenium.Builders
{
    using LiveDocs.Diagrams.Graph.Executable.Builders;
    using LiveDocs.Diagrams.Selenium.BuilderImplementations;
    using LiveDocs.Diagrams.Selenium.Models;

    public class UiSeleniumFlowBuilder
    {
        private readonly FlowBuilder flowBuilder;        

        public UiSeleniumFlowBuilder()
        {
            this.flowBuilder = new FlowBuilder();
        }

        public ISeleniumStartViaBuilder FromStartTo<TState>() where TState : SeleniumScreen, ISeleniumQueryable
        {          
            return new SeleniumStartViaBuilder(this.flowBuilder.FromStartTo<TState>());
        }
    }
}