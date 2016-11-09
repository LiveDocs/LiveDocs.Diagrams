namespace LiveDocs.Diagrams.Graph.Executable.Strategies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using LiveDocs.Diagrams.Graph.Executable.Models;
    using LiveDocs.Diagrams.Graph.Executable.Publishing;
    using LiveDocs.Diagrams.Graph.Executable.Services;
    using LiveDocs.Diagrams.Graph.Models;

    public class EndToEndPathStrategy : IPathTestStrategy<IState, ITransition>
    {
        private readonly ICommandResolver commandResolver;

        private readonly IQueryResolver queryResolver;

        public EndToEndPathStrategy(ICommandResolver commandResolver, IQueryResolver queryResolver)
        {
            if (commandResolver == null)
            {
                throw new ArgumentNullException(nameof(commandResolver));
            }

            if (queryResolver == null)
            {
                throw new ArgumentNullException(nameof(queryResolver));
            }

            this.commandResolver = commandResolver;
            this.queryResolver = queryResolver;
        }

        public Test GetTest(Path<Guid, IState, ITransition> path, IEventPublisherFactory publisherFactory)
        {
            var executableActions = new List<IExecutableAction>();

            var pathEdges = path.Edges.ToList();
            for (var i = 0; i < pathEdges.Count; i++)
            {
                var edge = pathEdges[i];

                if (edge.Target is IDecision)
                {
                    var nextEdge = pathEdges[i + 1];                    
                    executableActions.Add(this.GetExecutableAction(nextEdge));
                }
                else if (edge.Source is IDecision)
                {
                    var previousEdge = pathEdges[i - 1];
                    executableActions.Add(this.GetExecutableAction(previousEdge));
                }
                else
                {
                    executableActions.Add(this.GetExecutableAction(edge));
                }
            }

            var endScreen = pathEdges.LastOrDefault()?.Target;
            if (endScreen == null)
            {
                throw new InvalidOperationException("No end screen found.");
            }

            var query = this.queryResolver.GetQuery(endScreen);
            if (query == null)
            {
                throw new InvalidOperationException(
                    $"The end screen {endScreen.GetType()} does not have a query defined");
            }

            return new Test(path.ToString(), executableActions, query, publisherFactory);
        }

        private IExecutableAction GetExecutableAction(ITransition transition)
        {
            var command = this.commandResolver.GetCommand(transition.Action);
            if (command == null)
            {
                throw new InvalidOperationException(
                    $"No command found for action {transition.Action.Name} ({transition.Action.GetType()})");
            }

            return new ExecutableAction(
                new DescriptiveAction(transition.Source.Name, transition.Action), 
                command);
        }
    }
}