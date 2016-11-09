namespace LiveDocs.Diagrams.Graph.Executable.UnitTests.Models
{
    public class TotalContext
    {        
        private int total;     

        public TotalContext Add(Question question, Answer answer)
        {
            this.total += question.Id + answer.Id;
            return this;
        }

        public int Total()
        {
            return this.total;
        }
    }
}