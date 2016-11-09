namespace LiveDocs.Diagrams.Graph.Executable.Events
{
    using System;

    using LiveDocs.Diagrams.Graph.Executable.Commands;

    public class CommandExecutionEvent : IEvent
    {
        public CommandExecutionEvent(ICommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            this.Command = command;
        }

        public ICommand Command { get; }

        public string Title => $"{this.Command.Name}";
    }
}