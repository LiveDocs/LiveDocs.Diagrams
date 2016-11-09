namespace LiveDocs.Diagrams.Graph.UnitTests.Tests
{
    using System;
    using System.Collections.Generic;

    using LiveDocs.Diagrams.Graph.Models;
    using LiveDocs.Diagrams.Graph.UnitTests.Models;

    using Ploeh.AutoFixture.Xunit2;

    using Xunit;    

    public class PathTests
    {
        [Theory]
        [AutoData]
        public void NonNamedReturnsVertexIds(
            Graph<Guid, TestVertex, TestEdge<TestVertex>> graph, 
            Guid guidOne, 
            Guid guidTwo)
        {
            var path = new Path<TestVertex, TestEdge<TestVertex>>(new List<TestEdge<TestVertex>>
            {
                new TestEdge<TestVertex>(new TestVertex(guidOne), new TestVertex(guidTwo))
            });

            Assert.Equal($"{guidOne} -> {guidTwo}", path.ToString());
        }

        [Theory]
        [AutoData]
        public void NamedReturnsVertexNames(
            Graph<Guid, TestVertexNamed, TestEdge<TestVertexNamed>> graph, 
            string nameOne, 
            string nameTwo)
        {
            var path = new Path<TestVertexNamed, TestEdge<TestVertexNamed>>(new List<TestEdge<TestVertexNamed>>
            {
                new TestEdge<TestVertexNamed>(new TestVertexNamed(nameOne), new TestVertexNamed(nameTwo))
            });

            Assert.Equal($"{nameOne} -> {nameTwo}", path.ToString());
        }
    }
}
