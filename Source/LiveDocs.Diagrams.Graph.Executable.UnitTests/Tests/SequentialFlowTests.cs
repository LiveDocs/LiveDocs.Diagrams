namespace LiveDocs.Diagrams.Graph.Executable.UnitTests.Tests
{
    using System.Collections.Generic;
    
    using LiveDocs.Diagrams.Graph.Executable.Processors;
    using LiveDocs.Diagrams.Graph.Executable.UnitTests.Attributes;
    using LiveDocs.Diagrams.Graph.Executable.UnitTests.Models;
    using LiveDocs.Diagrams.Graph.Factories;

    using Ploeh.AutoFixture.Xunit2;

    using Xunit;

    public class SequentialFlowTests
    {
        [Theory] 
        [AutoData]
        public void ToGraphWithDecisionsOutputsGraph(            
            IEnumerable<QuestionWrapper> questions,
            [Frozen]StringToGuidIdFactory idFactory,            
            [QuestionSequentialFlowCreator]QuestionSequentialFlow sequentialFlow,
            MermaidProcessor mermaidProcessor)
        {
            var graph = sequentialFlow.ToGraph(questions);
            var mermaid = mermaidProcessor.Process(graph);
            Assert.NotNull(mermaid);
        }

        [Theory]
        [AutoData]
        public void ToGraphWithPathResultsOutputsGraph(
            IEnumerable<QuestionWrapper> questions,
            [Frozen]StringToGuidIdFactory idFactory,
            [QuestionSequentialFlowCreator]QuestionSequentialFlow sequentialFlow,
            MermaidProcessor mermaidProcessor)
        {
            var pathResults = sequentialFlow.GetPathResults(questions);
            var graph = sequentialFlow.ToGraph(pathResults);
            var mermaid = mermaidProcessor.Process(graph);
            Assert.NotNull(mermaid);
        }

        //[Theory]
        //[AutoData]
        //public void TestIndividualPathReturnsExpectedResult(
        //    IEnumerable<QuestionWrapper> questions,
        //    [Frozen] StringToGuidIdFactory idFactory,
        //    [QuestionSequentialFlowCreator] QuestionSequentialFlow sequentialFlow)
        //{
        //    sequentialFlow.TestPath()            
        //}
    }
}