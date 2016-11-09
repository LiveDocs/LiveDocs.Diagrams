namespace LiveDocs.Diagrams.Ui.BuilderImplementations
{
    using System;
    
    using LiveDocs.Diagrams.Ui.Builders;
    using LiveDocs.Diagrams.Ui.Helpers;
    using LiveDocs.Diagrams.Ui.Models;

    internal class StartViaBuilder : IStartViaBuilder
    {
        private readonly UiFlow uiFlow;

        private readonly CreatedInstances createdInstances;

        private readonly IState state;

        public StartViaBuilder(UiFlow uiFlow, CreatedInstances createdInstances, IState state)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }

            this.uiFlow = uiFlow;
            this.createdInstances = createdInstances;
            this.state = state;
        }      

        public IFlowBuilder Via(IAction action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            return this.Via((from, to) => action);
        }

        public IFlowBuilder Via(Func<IState, IState, IAction> actionFactory)
        {
            var startState = new StartState();
            this.uiFlow.AddStatesAndTransition(new Transition(
               startState,
               this.state,
               actionFactory(startState, this.state)));

            return new FlowBuilder(this.uiFlow, this.createdInstances);
        }

        public IFlowBuilder Via<TAction>() where TAction : class, IAction
        {
            var action = this.createdInstances.GetOrAdd<TAction>(
                InstanceHelper.CreateInstance<TAction>());

            return this.Via(action);
        }
    }
}