namespace LiveDocs.Diagrams.Graph.Executable.Commands
{
    using System.Collections.Generic;
    using System.Linq;

    public class CompositeCommand : ICommand
    {
        private IEnumerable<ICommand> commands;

        public CompositeCommand(params ICommand[] commands)
        {
            this.commands = commands.Where(c => c != null);
        }

        public string Name => string.Join(", ", this.Commands.Select(c => c.Name));

        private IEnumerable<ICommand> Commands => this.commands ?? (this.commands = Enumerable.Empty<ICommand>());

        public void Execute()
        {
            foreach (var command in this.Commands)
            {
                command.Execute();
            }
        }
    }
}