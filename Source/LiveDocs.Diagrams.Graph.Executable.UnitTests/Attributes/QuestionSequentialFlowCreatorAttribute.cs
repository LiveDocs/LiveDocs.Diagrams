namespace LiveDocs.Diagrams.Graph.Executable.UnitTests.Attributes
{
    using LiveDocs.Diagrams.Graph.Executable.UnitTests.Factories;
    using LiveDocs.Diagrams.Graph.Executable.UnitTests.Tests;

    public class QuestionSequentialFlowCreatorAttribute : CustomizeWithAttribute
    {
        public QuestionSequentialFlowCreatorAttribute() : base(typeof(MySequentialFlowFactory))
        {
        }
    }
}