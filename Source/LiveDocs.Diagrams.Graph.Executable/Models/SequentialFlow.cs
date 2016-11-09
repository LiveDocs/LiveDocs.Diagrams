namespace LiveDocs.Diagrams.Graph.Executable.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Graph.Models;

    using LiveDocs.Diagrams.Graph.Executable.Services;
    using LiveDocs.Diagrams.Graph.Factories;

    public class SequentialFlow<TContext, TDecision, TSelection, TResult>
        where TDecision : ISequentialDecision<TSelection>
        where TSelection : ISelection
    {
        private readonly Func<TContext> pathStart;

        private readonly Func<TDecision, TSelection, TContext, TContext> decisionSelector;

        private readonly Func<TContext, TResult> pathEnd;

        private readonly IGuidIdFactory<string> idFactory;

        public SequentialFlow(
            IGuidIdFactory<string> idFactory,
            Func<TContext> pathStart,
            Func<TDecision, TSelection, TContext, TContext> decisionSelector,
            Func<TContext, TResult> pathEnd)
        {
            this.idFactory = idFactory;
            this.pathStart = pathStart;
            this.decisionSelector = decisionSelector;
            this.pathEnd = pathEnd;
        }

        public TResult TestPath(List<TDecision> decisions, IEnumerable<DecisionSelection<TDecision, TSelection>> decisionSelections)
        {
            var context = this.pathStart();

            context = decisionSelections.Aggregate(
                context,
                (current, decisionSelection) =>
                    this.decisionSelector(decisionSelection.Decision, decisionSelection.Selection, current));

            return this.pathEnd(context);
        }

        private IEnumerable<IEnumerable<DecisionSelection<TDecision, TSelection>>> GetPaths(
            IEnumerable<TDecision> decisions)
        {
            var questionAnswers = decisions
                .Select(q => q.Selections.Select(a => new DecisionSelection<TDecision, TSelection>(q, a)).ToArray())
                .ToArray();

            var paths = new SetService()
                .GetCombinations(questionAnswers)
                .ToList();

            return paths;
        }

        public IEnumerable<PathResult<TDecision, TSelection, TResult>> GetPathResults(IEnumerable<TDecision> decisions)
        {
            var paths = this.GetPaths(decisions).ToList();
            foreach (var path in paths)
            {
                var pathList = path.ToList();
                var context = this.pathStart();

                context = pathList.Aggregate(
                    context, (current, state) => this.decisionSelector(state.Decision, state.Selection, current));

                var result = this.pathEnd(context);
                yield return new PathResult<TDecision, TSelection, TResult>(pathList, result);
            }
        }

        public Graph<IState, ITransition> ToGraph(IEnumerable<TDecision> decisions)
        {
            var graph = new Graph<IState, ITransition>();

            var paths = this.GetPaths(decisions).ToList();

            for (var i = 0; i < paths.Count; i++)
            {
                var path = paths[i].ToList();

                var context = this.pathStart();
                var pathId = "Q";

                for (var j = 0; j < path.Count; j++)
                {
                    var decisionSelection = path[j];
                    var isLastVertex = j == path.Count - 1;

                    var edgeId = $"{decisionSelection.Decision.Id}{decisionSelection.Selection.Id}";

                    context = this.decisionSelector(decisionSelection.Decision, decisionSelection.Selection, context);
                    var sourceDecision = decisions.First(q => q.Id == decisionSelection.Decision.Id);
                    var selectedAnswer = sourceDecision.Selections.First(s => s.Id == decisionSelection.Selection.Id);
                    var targetQuestion = isLastVertex 
                        ? this.pathEnd(context).ToString() 
                        : decisions.First(q => q.Id == path[j + 1].Decision.Id).Id.ToString();

                    var targetVertex = isLastVertex 
                        ? new State(this.idFactory.GetOrAdd(pathId + edgeId), targetQuestion)
                        : new Decision(this.idFactory.GetOrAdd(pathId + edgeId), targetQuestion) as IState;

                    graph.AddVerticesAndEdge(
                      new Transition(
                          new Decision(this.idFactory.GetOrAdd(pathId), sourceDecision.Name), 
                          targetVertex,
                          new Action(selectedAnswer.Name)));

                    pathId = pathId + edgeId;
                }
            }

            return graph;
        }

        public Graph<IState, ITransition> ToGraph(IEnumerable<PathResult<TDecision, TSelection, TResult>> pathResults)
        {
            var graph = new Graph<IState, ITransition>();
            var pathResultList = pathResults.ToList();

            for (var i = 0; i < pathResultList.Count; i++)
            {
                var path = pathResultList[i];

                var context = this.pathStart();
                var pathId = "Q";

                for (var j = 0; j < path.DecisionSelections.Count(); j++)
                {
                    var questionAnswer = path.DecisionSelections.ElementAt(j);
                    var lastVertex = j == path.DecisionSelections.Count() - 1;

                    var edgeId = $"{questionAnswer.Decision.Id}{questionAnswer.Selection.Id}";

                    context = this.decisionSelector(questionAnswer.Decision, questionAnswer.Selection, context);
                    var targetQuestion = lastVertex ? this.pathEnd(context).ToString() : path.DecisionSelections.ElementAt(j + 1).Decision.Id.ToString();

                    graph.AddVerticesAndEdge(
                      new Transition(
                          new Decision(this.idFactory.GetOrAdd(pathId), questionAnswer.Decision.Name), 
                          new Decision(this.idFactory.GetOrAdd(pathId + edgeId), targetQuestion),
                          new Action(questionAnswer.Selection.Name)));

                    pathId = pathId + edgeId;
                }
            }

            return graph;
        }
    }
}