namespace LiveDocs.Diagrams.Ui.Models
{
    using System;

    public class State : IState
    {
        public State(Guid id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public State(string name) : this(Guid.NewGuid(), name)
        {
        }

        public Guid Id { get; }

        public string Name { get; }

        public override bool Equals(object obj)
        {
            var state = obj as IState;
            return state != null && this.Id.Equals(state.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
