namespace LiveDocs.Diagrams.Graph.Executable.Models
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

        public override bool Equals(object obj)
        {
            var state = obj as IAction;
            return state != null && this.Id.Equals(state.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}