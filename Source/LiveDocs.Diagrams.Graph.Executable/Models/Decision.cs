namespace LiveDocs.Diagrams.Graph.Executable.Models
{
    using System;

    public class Decision : IDecision
    {
        public Decision(Guid id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Decision(string name) : this(Guid.NewGuid(), name)
        {
        }

        public Guid Id { get; }

        public string Name { get; }

        public override bool Equals(object obj)
        {
            var state = obj as IDecision;
            return state != null && this.Id.Equals(state.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}