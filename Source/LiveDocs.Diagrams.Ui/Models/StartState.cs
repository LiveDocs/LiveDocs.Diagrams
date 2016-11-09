namespace LiveDocs.Diagrams.Ui.Models
{
    using System;    

    public class StartState : IState
    {
        public static Guid Identifier = Guid.NewGuid();
        
        public StartState()
        {
            this.Id = Identifier;
            this.Name = "Start";
        }

        public Guid Id { get; }

        public string Name { get; }
    }
}