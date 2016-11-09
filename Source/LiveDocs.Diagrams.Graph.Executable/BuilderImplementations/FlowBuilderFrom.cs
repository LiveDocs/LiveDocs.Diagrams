namespace LiveDocs.Diagrams.Graph.Executable.BuilderImplementations
{
    using LiveDocs.Diagrams.Graph.Executable.Builders;
    using LiveDocs.Diagrams.Graph.Executable.Helpers;
    using LiveDocs.Diagrams.Graph.Executable.Models;

    internal class FlowBuilderFrom : IFlowBuilderFrom
    {
        private readonly Flow flow;

        private readonly CreatedInstances createdInstances;

        private readonly IState sourceState;

        public FlowBuilderFrom(Flow flow, CreatedInstances createdInstances, IState sourceState)
        {
            this.flow = flow;
            this.createdInstances = createdInstances;
            this.sourceState = sourceState;
        }

        public IFlowBuilderTo To(IState targetState)
        {
            return new FlowBuilderTo(
                this.flow, 
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