namespace LiveDocs.Diagrams.Graph.Executable.Models
{
    using System;
    using System.Collections.Generic;

    using LiveDocs.Diagrams.Graph.Models;

    public class Flow
    {
        private readonly Graph<IState, ITransition> graph;

        public Flow()
        {
            this.graph = new Graph<IState, ITransition>();
        }

        public Flow(IEnumerable<ITransition> transitions)
        {
            if (transitions == null)
            {
                throw new ArgumentNullException(nameof(transitions));
            }

            this.graph = new Graph<IState, ITransition>(transitions);
        }

        public void AddStatesAndTransition(ITransition transition)
        {
            this.graph.AddVerticesAndEdge(transition);
        }

        public void AddTransition(ITransition transition)
        {
            try
            {
                this.graph.AddEdge(transition);
            }
            catch (KeyNotFoundException)
            {
                throw new StateMissingException($"There was an error adding the transition. Please ensure the source and target states have been added, or use AddStatesAndTransition");
            }            
        }

        public void AddState(IState state)
        {
            this.graph.AddVertex(state);
        }

        public Graph<IState, ITransition> ToGraph()
        {
            return this.graph;
        }
    }
}