namespace LiveDocs.Diagrams.Ui.Builders
{    
    using LiveDocs.Diagrams.Ui.BuilderImplementations;
    using LiveDocs.Diagrams.Ui.Helpers;
    using LiveDocs.Diagrams.Ui.Models;

    public class UiFlowBuilder
    {
        private readonly UiFlow uiFlow;

        private readonly CreatedInstances createdInstances;

        public UiFlowBuilder()
        {
            this.uiFlow = new UiFlow();
            this.createdInstances = new CreatedInstances();
        }

        public IStartViaBuilder FromStartTo(IState state)
        {
            return new StartViaBuilder(this.uiFlow, this.createdInstances, state);
        }

        public IStartViaBuilder FromStartTo<TState>() where TState : class, IState
        {
            var state = this.createdInstances.GetOrAdd<TState>(
                InstanceHelper.CreateInstance<TState>());

            return this.FromStartTo(state);
        }
    }
}