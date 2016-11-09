namespace LiveDocs.Diagrams.Ui.Strategies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using LiveDocs.Diagrams.Graph.Model;
    using LiveDocs.Diagrams.Graph.Services;
    using LiveDocs.Diagrams.Ui.Enums;
    using LiveDocs.Diagrams.Ui.Models;

    public class DefaultPathResolverStrategy : IPathResolverStrategy<IVertex, ITransition>        
    {
        private Graph<IVertex, ITransition> graph;

        private List<Guid> visitedStates;

        private List<Guid> visitedEdges;

        public IEnumerable<Path<IVertex, ITransition>> GetPaths(Graph<IVertex, ITransition> graph, IVertex startState)
        {
            this.graph = graph;

            var currentPathResolverState = PathResolverState.Start;
            IVertex currentGraphState = null;

            var paths = new List<Path<IVertex, ITransition>>();
            var pathEdges = new Stack<ITransition>();

            while (currentPathResolverState != PathResolverState.Complete)
            {
                switch (currentPathResolverState)
                {
                    case PathResolverState.Start:
                        paths = new List<Path<IVertex, ITransition>>();
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
                            var previouslyVisistedDecision = nextUnvisitedEdge.Target is Decision
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
                        paths.Add(new Path<IVertex, ITransition>(new List<ITransition>(pathEdges.Reverse())));
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
       
        private ITransition FirstUnvisitedEdge(IVertex state)
        {
            return this.graph.OutEdges(state).FirstOrDefault(e => !this.visitedEdges.Contains(e.Id));
        }
    }
}