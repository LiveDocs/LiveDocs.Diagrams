namespace LiveDocs.Diagrams.Graph.Executable.Models
{
    public class DecisionSelection<TDecision, TSelection>
        where TDecision : ISequentialDecision<TSelection>
        where TSelection : ISelection
    {
        public DecisionSelection(TDecision decision, TSelection selection)
        {
            this.Decision = decision;
            this.Selection = selection;
        }

        public TDecision Decision { get; }

        public TSelection Selection { get; }
    }
}