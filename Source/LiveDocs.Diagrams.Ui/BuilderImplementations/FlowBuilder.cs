namespace LiveDocs.Diagrams.Ui.BuilderImplementations
{
    using System;

    using LiveDocs.Diagrams.Ui.Builders;
    using LiveDocs.Diagrams.Ui.Helpers;
    using LiveDocs.Diagrams.Ui.Models;

    internal class FlowBuilder : IFlowBuilder
    {
        private readonly UiFlow uiFlow;

        private readonly CreatedInstances createdInstances;

        public FlowBuilder(UiFlow uiFlow, CreatedInstances createdInstances)
        {
            this.uiFlow = uiFlow;
            this.createdInstances = createdInstances;
        }

        public IFlowBuilderFrom From<TState>() where TState : class, IState
        {
            var state = this.createdInstances.GetOrAdd<TState>(
                InstanceHelper.CreateInstance<TState>());

            return this.From(state);
        }

        public IFlowBuilderFrom From(IState state)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }

            return new FlowBuilderFrom(this.uiFlow, this.createdInstances, state);
        } 

        public UiFlow Build()
        {
            return this.uiFlow;
        }
    }
}