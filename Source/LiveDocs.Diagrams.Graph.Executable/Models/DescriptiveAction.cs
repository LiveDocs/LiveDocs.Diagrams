namespace LiveDocs.Diagrams.Graph.Executable.Models
{
    using System;

    public class DescriptiveAction : IAction
    {
        private readonly IAction action;

        private readonly string name;

        public DescriptiveAction(string name, IAction action)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            this.name = name;
            this.action = action;
        }

        public Guid Id => this.action.Id;

        public string Name => $"{this.name} ({this.action.Name})";
    }
}