namespace LiveDocs.Diagrams.Graph.Executable.BuilderImplementations
{
    using System;

    using LiveDocs.Diagrams.Graph.Executable.Builders;
    using LiveDocs.Diagrams.Graph.Executable.Helpers;
    using LiveDocs.Diagrams.Graph.Executable.Models;

    internal class FlowBuilderStart : IFlowBuilderStart
    {
        private readonly Flow flow;

        private readonly CreatedInstances createdInstances;

        public FlowBuilderStart(Flow flow, CreatedInstances createdInstances)
        {
            this.flow = flow;
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

            return new FlowBuilderFrom(this.flow, this.createdInstances, state);
        } 

        public Flow Build()
        {
            return this.flow;
        }
    }
}