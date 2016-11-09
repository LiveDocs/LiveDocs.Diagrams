namespace LiveDocs.Diagrams.Graph.Executable.Models
{
    using System.Collections.Generic;

    public class PathResult<TDecision, TSelection, TResult>
        where TDecision : ISequentialDecision<TSelection>
        where TSelection : ISelection
    {
        public PathResult(IEnumerable<DecisionSelection<TDecision, TSelection>> decisionSelections, TResult result)
        {
            this.DecisionSelections = decisionSelections;
            this.Result = result;
        }

        public IEnumerable<DecisionSelection<TDecision, TSelection>> DecisionSelections { get; }

        public TResult Result { get; }
    }
}