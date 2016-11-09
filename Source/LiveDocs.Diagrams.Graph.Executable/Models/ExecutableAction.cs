namespace LiveDocs.Diagrams.Graph.Executable.Models
{
    using System;

    using LiveDocs.Diagrams.Graph.Executable.Commands;

    public class ExecutableAction : IExecutableAction
    {
        private readonly IAction action;

        public ExecutableAction(IAction action, ICommand command)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            this.action = action;
            this.Command = command;
        }

        public Guid Id => this.action.Id;

        public string Name => this.action.Name;

        public ICommand Command { get; }
    }
}