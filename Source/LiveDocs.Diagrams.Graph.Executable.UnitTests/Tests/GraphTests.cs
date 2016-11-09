namespace LiveDocs.Diagrams.Graph.Executable.UnitTests.Tests
{
    using System;
    using System.Linq;

    using Graph.Models;

    using LiveDocs.Diagrams.Graph.Executable.Models;

    using Xunit;

    public class GraphTests
    {
        [Fact]
        public void ParallelEdgesNotAllowed()
        {
            var guidOne = Guid.NewGuid();
            var guidTwo = Guid.NewGuid();

            var graph = new Graph<IState, ITransition>();
            graph.AddVerticesAndEdge(
                new Transition(
                    new State(guidOne, "State One"),
                    new State(guidTwo, "State Two"),
                    new Executable.Models.Action("Test")));

            graph.AddVerticesAndEdge(
                new Transition(
                    new State(guidOne, "State One"),
                    new State(guidTwo, "State Two"),
                    new Executable.Models.Action("Test 2")));

            Assert.Equal(1, graph.Edges.Count());
        }


    }
}
