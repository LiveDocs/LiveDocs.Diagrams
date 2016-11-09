namespace LiveDocs.Diagrams.Ui.BuilderImplementations
{
    using System;

    using LiveDocs.Diagrams.Ui.Builders;
    using LiveDocs.Diagrams.Ui.Helpers;
    using LiveDocs.Diagrams.Ui.Models;

    internal class FlowBuilderTo : IFlowBuilderTo
    {
        private readonly UiFlow uiFlow;

        private readonly CreatedInstances createdInstances;

        private readonly IState sourceState;

        private readonly IState targetState;

        public FlowBuilderTo(UiFlow uiFlow, CreatedInstances createdInstances, IState sourceState, IState targetState)
        {
            this.uiFlow = uiFlow;
            this.createdInstances = createdInstances;
            this.sourceState = sourceState;
            this.targetState = targetState;
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
            if (actionFactory == null)
            {
                throw new ArgumentNullException(nameof(actionFactory));
            }

            this.uiFlow.AddStatesAndTransition(new Transition(
              this.sourceState,
              this.targetState,
              actionFactory(this.sourceState, this.targetState)));

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