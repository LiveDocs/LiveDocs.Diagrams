namespace LiveDocs.Diagrams.Graph.Executable.UnitTests.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using LiveDocs.Diagrams.Graph.Executable.Models;
    using LiveDocs.Diagrams.Graph.Executable.UnitTests.Tests;
    using LiveDocs.Diagrams.Graph.Factories;

    public class QuestionWrapper : ISequentialDecision<AnswerWrapper>
    {
        private readonly Question question;

        private readonly IGuidIdFactory<string> idFactory;

        public QuestionWrapper(StringToGuidIdFactory idFactory, Question question)
        {
            this.idFactory = idFactory;
            this.question = question;            
        }

        public Guid Id => this.idFactory.GetOrAdd(this.question.Id.ToString());

        public string Name => this.question.Title;

        public IEnumerable<AnswerWrapper> Selections
        {
            get
            {
                return this.question.Answers.Select(a => new AnswerWrapper(this.idFactory, this.question, a));
            }
        }

        public Question Question => this.question;
    }
}