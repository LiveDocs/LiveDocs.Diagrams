namespace LiveDocs.Diagrams.Ui.Events
{
    using System;

    using LiveDocs.Diagrams.Ui.Commands;

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