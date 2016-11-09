namespace LiveDocs.Diagrams.Graph.Executable.Strategies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using LiveDocs.Diagrams.Graph.Executable.Enums;
    using LiveDocs.Diagrams.Graph.Executable.Models;
    using LiveDocs.Diagrams.Graph.Models;
    using LiveDocs.Diagrams.Graph.Services;

    public class DefaultPathResolverStrategy : IPathResolverStrategy<IVertex<Guid>, ITransition>
    {
        private Graph<Guid, IVertex<Guid>, ITransition> graph;

        private List<Guid> visitedStates;

        private List<Guid> visitedEdges;

        public IEnumerable<Path<Guid, IVertex<Guid>, ITransition>> GetPaths(
            Graph<Guid, IVertex<Guid>, ITransition> graph, 
            IVertex<Guid> startState)
        {
            this.graph = graph;

            var currentPathResolverState = PathResolverState.Start;
            IVertex<Guid> currentGraphState = null;

            var paths = new List<Path<Guid, IVertex<Guid>, ITransition>>();
            var pathEdges = new Stack<ITransition>();

            while (currentPathResolverState != PathResolverState.Complete)
            {
                switch (currentPathResolverState)
                {
                    case PathResolverState.Start:
                        paths = new List<Path<Guid, IVertex<Guid>, ITransition>>();
                        pathEdges = new Stack<ITransition>();
                        this.visitedStates = new List<Guid>();
                        this.visitedEdges = new List<Guid>();

                        currentGraphState = startState;
                        currentPathResolverState = PathResolverState.Forward;
                        break;

                    case PathResolverState.Forward:
                        var nextUnvisitedEdge = this.FirstUnvisitedEdge(currentGraphState);
                        if (nextUnvisitedEdge == null)
                        {
                            currentPathResolverState = PathResolverState.PathComplete;
                        }
                        else
                        {
                            // If the next state is a decision, and we have visited it before, then don't add the edge
                            var previouslyVisistedDecision = nextUnvisitedEdge.Target is IDecision
                                && this.visitedStates.Contains(nextUnvisitedEdge.Target.Id);
                            
                            if (!previouslyVisistedDecision)
                            {
                                pathEdges.Push(nextUnvisitedEdge);
                            }

                            this.visitedEdges.Add(nextUnvisitedEdge.Id);
                            currentGraphState = nextUnvisitedEdge.Target;

                            if (this.visitedStates.Contains(currentGraphState.Id))
                            {
                                currentPathResolverState = PathResolverState.PathComplete;
                            }
                            else
                            {
                                this.visitedStates.Add(currentGraphState.Id);
                            }    
                        }

                        break;

                    case PathResolverState.PathComplete:
                        paths.Add(new Path<Guid, IVertex<Guid>, ITransition>(new List<ITransition>(pathEdges.Reverse())));
                        currentPathResolverState = PathResolverState.Backward;
                        break;

                    case PathResolverState.Backward:
                        if (!pathEdges.Any())
                        {
                            currentPathResolverState = PathResolverState.Complete;
                        }
                        else
                        {                            
                            currentGraphState = pathEdges.Pop().Source;

                            var unvisitedEdge = this.FirstUnvisitedEdge(currentGraphState);
                            if (unvisitedEdge != null)
                            {
                                currentPathResolverState = PathResolverState.Forward;
                            }
                        }

                        break;

                    case PathResolverState.Complete:
                        continue;

                    default:
                        throw new InvalidOperationException(
                            $"Unsupported path resolver state '{currentPathResolverState}'");
                }
            }

            return paths;
        }
       
        private ITransition FirstUnvisitedEdge(IVertex<Guid> state)
        {
            return this.graph.OutEdges(state).FirstOrDefault(e => !this.visitedEdges.Contains(e.Id));
        }
    }
}