namespace LiveDocs.Diagrams.Graph.Executable.UnitTests.Models
{
    using System;

    using LiveDocs.Diagrams.Graph.Executable.Models;
    using LiveDocs.Diagrams.Graph.Factories;

    public class AnswerWrapper : ISelection
    {
        private readonly Question question;

        private readonly Answer answer;

        private readonly IGuidIdFactory<string> toGuidIdFactory;

        public AnswerWrapper(IGuidIdFactory<string> idFactory, Question question, Answer answer)
        {
            this.question = question;
            this.answer = answer;
            this.toGuidIdFactory = idFactory;
        }

        public Guid Id => this.toGuidIdFactory.GetOrAdd($"{this.question.Id}{this.answer.Id}");

        public string Name => this.answer.Title;

        public Answer Answer => this.answer;
    }
}