namespace LiveDocs.Diagrams.Ui.Models
{
    using System;

    public class Action : IAction
    {        
        public Action(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            this.Id = Guid.NewGuid();
            this.Name = name;
        }

        public Guid Id { get; }
        
        public string Name { get; }
    }
}