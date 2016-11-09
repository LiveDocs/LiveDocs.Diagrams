namespace LiveDocs.Diagrams.Ui.UnitTests.Tests
{
    using System;
    using System.Linq;

    using LiveDocs.Diagrams.Graph.Executable.Models;
    using LiveDocs.Diagrams.Ui.UnitTests.Attributes;

    using Xunit;

    public class UiFlowTests
    {        
        [Theory]
        [AutoMoqData]
        public void AddingTransitionWithMissingStatesThrowsException(UiFlow uiFlow, Transition transition)
        {
            Assert.Throws<StateMissingException>(() => uiFlow.AddTransition(transition));
        }

        [Theory]
        [AutoMoqData]
        public void AddingTransitionAndStatesAddsStates(UiFlow uiFlow, Transition transition)
        {
            uiFlow.AddStatesAndTransition(transition);
            var graph = uiFlow.ToGraph();
            Assert.Equal(2, graph.Vertices.Count());
        }

        [Theory]
        [AutoMoqData]
        public void AddingTransitionAndStatesAddsEdge(UiFlow uiFlow, Transition transition)
        {
            uiFlow.AddStatesAndTransition(transition);
            var graph = uiFlow.ToGraph();
            Assert.Equal(1, graph.Edges.Count());
        }

        [Theory]
        [AutoMoqData]
        public void AddingStatesWithSameIdsAddsOnce(UiFlow uiFlow, Guid id)
        {
            var screenOne = new State(id, "State 1");
            var screenTwo = new State(id, "State 2");

            uiFlow.AddState(screenOne);
            uiFlow.AddState(screenTwo);

            var graph = uiFlow.ToGraph();
            Assert.Equal(1, graph.Vertices.Count());
        }
    }
}
