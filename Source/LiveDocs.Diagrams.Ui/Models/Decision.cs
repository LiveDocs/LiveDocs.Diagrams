namespace LiveDocs.Diagrams.Ui.Models
{
    using System;    

    public class Decision : IState
    {
        public Decision(string name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
        }

        public Guid Id { get; }

        public string Name { get; }
    }
}