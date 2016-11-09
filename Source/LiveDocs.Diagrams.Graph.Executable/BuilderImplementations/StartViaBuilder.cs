namespace LiveDocs.Diagrams.Graph.Executable.BuilderImplementations
{
    using System;

    using LiveDocs.Diagrams.Graph.Executable.Builders;
    using LiveDocs.Diagrams.Graph.Executable.Helpers;
    using LiveDocs.Diagrams.Graph.Executable.Models;

    internal class StartViaBuilder : IStartViaBuilder
    {
        private readonly Flow flow;

        private readonly CreatedInstances createdInstances;

        private readonly IState state;

        public StartViaBuilder(Flow flow, CreatedInstances createdInstances, IState state)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }

            this.flow = flow;
            this.createdInstances = createdInstances;
            this.state = state;
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
            var startState = new StartState();
            this.flow.AddStatesAndTransition(new Transition(
               startState,
               this.state,
               actionFactory(startState, this.state)));

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