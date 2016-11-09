namespace LiveDocs.Diagrams.Graph.Executable.Builders
{
    using LiveDocs.Diagrams.Graph.Executable.BuilderImplementations;
    using LiveDocs.Diagrams.Graph.Executable.Helpers;
    using LiveDocs.Diagrams.Graph.Executable.Models;

    public class FlowBuilder
    {
        private readonly Flow flow;

        private readonly CreatedInstances createdInstances;

        public FlowBuilder()
        {
            this.flow = new Flow();
            this.createdInstances = new CreatedInstances();
        }

        public IStartViaBuilder FromStartTo(IState state)
        {
            return new StartViaBuilder(this.flow, this.createdInstances, state);
        }

        public IStartViaBuilder FromStartTo<TState>() where TState : class, IState
        {
            var state = this.createdInstances.GetOrAdd<TState>(
                InstanceHelper.CreateInstance<TState>());

            return this.FromStartTo(state);
        }
    }
}