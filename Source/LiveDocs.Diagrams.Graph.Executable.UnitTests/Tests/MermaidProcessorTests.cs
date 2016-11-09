namespace LiveDocs.Diagrams.Graph.Executable.UnitTests.Tests
{
    using System;

    using LiveDocs.Diagrams.Graph.Executable.Builders;
    using LiveDocs.Diagrams.Graph.Executable.Models;
    using LiveDocs.Diagrams.Graph.Executable.Processors;

    using Ploeh.AutoFixture.Xunit2;

    using Xunit;

    using Action = LiveDocs.Diagrams.Graph.Executable.Models.Action;

    public class MermaidProcessorTests
    {
        [Theory]
        [AutoData]
        public void OutputsFromGraph(MermaidProcessor processor)
        {
            var loginScreen = new State("Login");
            var validCredentials = new Decision("Valid Credentials?");

            var flow = new FlowBuilder()
                .FromStartTo(loginScreen).Via(new Action("Navigate"))
                .From(loginScreen).To(validCredentials).Via(new Action("Submit"))
                .From(validCredentials).To(new State("Login Error")).Via(new Action("No"))
                .From(validCredentials).To(new State("Welcome")).Via(new Action("Yes"))
                .Build();

            var output = processor.Process(flow.ToGraph());
            Assert.NotNull(output);         
        }

        [Theory]
        [AutoData]
        public void OutputsFromGraphWithSameIds(MermaidProcessor processor)
        {            
            var flow = new FlowBuilder()
              .FromStartTo(new State(Guid.Parse("0B50B190-A8E3-4461-AB27-1E28775201C5"), "Login")).Via(new Action("Navigate"))
              .From(new State(Guid.Parse("0B50B190-A8E3-4461-AB27-1E28775201C5"), "Login")).To(new Decision(Guid.Parse("A4EDA007-76A1-4163-A286-9472B7BB8795"), "Valid Credentials?")).Via(new Action("Submit"))
              .From(new Decision(Guid.Parse("A4EDA007-76A1-4163-A286-9472B7BB8795"), "Valid Credentials?")).To(new State("Login Error")).Via(new Action("No"))
              .From(new Decision(Guid.Parse("A4EDA007-76A1-4163-A286-9472B7BB8795"), "Valid Credentials?")).To(new State("Welcome")).Via(new Action("Yes"))
              .Build();

            var output = processor.Process(flow.ToGraph());
            Assert.NotNull(output);
        }
    }
}