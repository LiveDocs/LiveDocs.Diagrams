namespace LiveDocs.Diagrams.Graph.Executable.UnitTests.Tests
{
    using System;
    using System.Linq;

    using LiveDocs.Diagrams.Graph.Executable.Builders;
    using LiveDocs.Diagrams.Graph.Executable.Models;
    using LiveDocs.Diagrams.Graph.Executable.UnitTests.Attributes;

    using Xunit;

    using Action = LiveDocs.Diagrams.Graph.Executable.Models.Action;

    public class FlowTests
    {        
        [Theory]
        [AutoMoqData]
        public void AddingTransitionWithMissingStatesThrowsException(Flow flow, Transition transition)
        {
            Assert.Throws<StateMissingException>(() => flow.AddTransition(transition));
        }

        [Theory]
        [AutoMoqData]
        public void AddingTransitionAndStatesAddsStates(Flow flow, Transition transition)
        {
            flow.AddStatesAndTransition(transition);
            var graph = flow.ToGraph();
            Assert.Equal(2, graph.Vertices.Count());
        }

        [Theory]
        [AutoMoqData]
        public void AddingTransitionAndStatesAddsEdge(Flow flow, Transition transition)
        {
            flow.AddStatesAndTransition(transition);
            var graph = flow.ToGraph();
            Assert.Equal(1, graph.Edges.Count());
        }

        [Theory]
        [AutoMoqData]
        public void AddingStatesWithSameIdsAddsOnce(Flow flow, Guid id)
        {
            var screenOne = new State(id, "State 1");
            var screenTwo = new State(id, "State 2");

            flow.AddState(screenOne);
            flow.AddState(screenTwo);

            var graph = flow.ToGraph();
            Assert.Equal(1, graph.Vertices.Count());
        }
    }
}
