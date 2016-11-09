namespace LiveDocs.Diagrams.Graph.Executable.UnitTests.Models
{
    public class Answer
    {
        public Answer(int id, string title)
        {
            this.Id = id;
            this.Title = title;
        }

        public int Id { get; }

        public string Title { get; }
    }
}