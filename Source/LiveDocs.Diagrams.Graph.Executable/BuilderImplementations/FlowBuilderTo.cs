namespace LiveDocs.Diagrams.Graph.Executable.BuilderImplementations
{
    using System;

    using LiveDocs.Diagrams.Graph.Executable.Builders;
    using LiveDocs.Diagrams.Graph.Executable.Helpers;
    using LiveDocs.Diagrams.Graph.Executable.Models;

    internal class FlowBuilderTo : IFlowBuilderTo
    {
        private readonly Flow flow;

        private readonly CreatedInstances createdInstances;

        private readonly IState sourceState;

        private readonly IState targetState;

        public FlowBuilderTo(Flow flow, CreatedInstances createdInstances, IState sourceState, IState targetState)
        {
            this.flow = flow;
            this.createdInstances = createdInstances;
            this.sourceState = sourceState;
            this.targetState = targetState;
        }

        public IFlowBuilderStart Via(IAction action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            return this.Via((from, to) => action);
        }

        public IFlowBuilderStart Via(Func<IState, IState, IAction> actionFactory)
        {
            if (actionFactory == null)
            {
                throw new ArgumentNullException(nameof(actionFactory));
            }

            this.flow.AddStatesAndTransition(new Transition(
              this.sourceState,
              this.targetState,
              actionFactory(this.sourceState, this.targetState)));

            return new FlowBuilderStart(this.flow, this.createdInstances);
        }

        public IFlowBuilderStart Via<TAction>() where TAction : class, IAction
        {
            var action = this.createdInstances.GetOrAdd<TAction>(
                InstanceHelper.CreateInstance<TAction>());

            return this.Via(action);
        }
    }
}