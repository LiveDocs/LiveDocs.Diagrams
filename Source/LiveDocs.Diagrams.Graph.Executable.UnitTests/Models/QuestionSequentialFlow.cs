namespace LiveDocs.Diagrams.Graph.Executable.UnitTests.Models
{
    using System;

    using LiveDocs.Diagrams.Graph.Executable.Models;
    using LiveDocs.Diagrams.Graph.Factories;

    public class QuestionSequentialFlow : SequentialFlow<TotalContext, QuestionWrapper, AnswerWrapper, int>
    {
        public QuestionSequentialFlow(
            StringToGuidIdFactory idFactory, 
            Func<TotalContext> pathStart, 
            Func<QuestionWrapper, AnswerWrapper, TotalContext, TotalContext> decisionSelector, 
            Func<TotalContext, int> pathEnd)
            : base(idFactory, pathStart, decisionSelector, pathEnd)
        {
        }
    }
}