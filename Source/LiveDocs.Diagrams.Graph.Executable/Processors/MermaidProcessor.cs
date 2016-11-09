namespace LiveDocs.Diagrams.Graph.Executable.Processors
{
    using System;
    using System.Text;

    using LiveDocs.Diagrams.Graph.Executable.Models;
    using LiveDocs.Diagrams.Graph.Models;

    public class MermaidProcessor
    {
        public string Process(
            Graph<IState, ITransition> graph, 
            MermaidFlowChartDirection direction = MermaidFlowChartDirection.TopBottom,
            bool includeStartState = false)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"graph {this.GetDirection(direction)}");

            foreach (var edge in graph.Edges)
            {
                if (!includeStartState && edge.Source.GetType() == typeof(StartState))
                {
                    continue;
                }

                sb.AppendLine($"{ToMermaid(edge.Source)}-->|{edge.Action.Name}|{ToMermaid(edge.Target)}");
            }

            return sb.ToString();
        }

        private string GetDirection(MermaidFlowChartDirection direction)
        {
            switch (direction)
            {
                case MermaidFlowChartDirection.TopBottom:
                    return "TB";
                
                case MermaidFlowChartDirection.BottomTop:
                    return "BT";

                case MermaidFlowChartDirection.RightLeft:
                    return "RL";

                case MermaidFlowChartDirection.LeftRight:
                    return "LR";

                default:
                    throw new InvalidOperationException($"Unexpected Mermaid flow chart direction value {direction}");
            }
        }

        private static string ToMermaid(IState state)
        {
            var textCharacters = state is IDecision ? new[] { '{', '}' } : new[] { '[', ']' };
            return $"{state.Id}{textCharacters[0]}\"{state.Name}\"{textCharacters[1]}";
        }
    }
}