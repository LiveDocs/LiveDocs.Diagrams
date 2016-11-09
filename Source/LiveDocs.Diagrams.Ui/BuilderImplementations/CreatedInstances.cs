namespace LiveDocs.Diagrams.Ui.BuilderImplementations
{
    using System;
    using System.Collections.Generic;
    
    using LiveDocs.Diagrams.Ui.Models;

    internal class CreatedInstances
    {
        private readonly IDictionary<Type, IState> states;

        private readonly IDictionary<Type, IAction> actions;

        public CreatedInstances()
        {
            this.states = new Dictionary<Type, IState>();
            this.actions = new Dictionary<Type, IAction>();
        }

        public IState GetOrAdd<TState>(IState addVertex)
        {
            if (this.states.ContainsKey(typeof(TState)))
            {
                return this.states[typeof(TState)];
            }

            this.states.Add(typeof(TState), addVertex);
            return addVertex;            
        }

        public IAction GetOrAdd<TAction>(IAction addAction)
        {
            if (this.actions.ContainsKey(typeof(TAction)))
            {
                return this.actions[typeof(TAction)];
            }

            this.actions.Add(typeof(TAction), addAction);
            return addAction;
        }
    }
}