namespace LiveDocs.Diagrams.Graph.Executable.UnitTests.Factories
{
    using LiveDocs.Diagrams.Graph.Executable.UnitTests.Models;    
    using LiveDocs.Diagrams.Graph.Factories;

    internal class MySequentialFlowFactory : InstanceFactory<QuestionSequentialFlow>
    {
        public override QuestionSequentialFlow CreateInstance()
        {
            return new QuestionSequentialFlow(
                this.CreateType<StringToGuidIdFactory>(),
                () => new TotalContext(),
                (q, a, c) => c.Add(q.Question, a.Answer),
                c => c.Total());
        }
    }
}