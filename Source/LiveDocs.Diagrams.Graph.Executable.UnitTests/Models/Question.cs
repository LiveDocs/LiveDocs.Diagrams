namespace LiveDocs.Diagrams.Graph.Executable.UnitTests.Models
{
    using System.Collections.Generic;

    public class Question
    {
        public Question(int id, string title, IEnumerable<Answer> answers)
        {
            this.Id = id;
            this.Title = title;
            this.Answers = answers;
        }

        public int Id { get; }

        public string Title { get; }

        public IEnumerable<Answer> Answers { get; }
    }
}