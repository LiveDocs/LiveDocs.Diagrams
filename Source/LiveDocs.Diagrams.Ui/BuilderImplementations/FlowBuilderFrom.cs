namespace LiveDocs.Diagrams.Ui.BuilderImplementations
{    
    using LiveDocs.Diagrams.Ui.Builders;
    using LiveDocs.Diagrams.Ui.Helpers;
    using LiveDocs.Diagrams.Ui.Models;

    internal class FlowBuilderFrom : IFlowBuilderFrom
    {
        private readonly UiFlow uiFlow;

        private readonly CreatedInstances createdInstances;

        private readonly IState sourceState;

        public FlowBuilderFrom(UiFlow uiFlow, CreatedInstances createdInstances, IState sourceState)
        {
            this.uiFlow = uiFlow;
            this.createdInstances = createdInstances;
            this.sourceState = sourceState;
        }

        public IFlowBuilderTo To(IState targetState)
        {
            return new FlowBuilderTo(
                this.uiFlow, 
                this.createdInstances, 
                this.sourceState, 
                targetState);
        }

        public IFlowBuilderTo To<TState>() where TState : class, IState
        {
            var state = this.createdInstances.GetOrAdd<TState>(
                InstanceHelper.CreateInstance<TState>());

            return this.To(state);
        }
    }
}