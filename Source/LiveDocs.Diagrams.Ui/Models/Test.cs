namespace LiveDocs.Diagrams.Ui.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using LiveDocs.Diagrams.Ui.Events;
    using LiveDocs.Diagrams.Ui.Publishing;
    using LiveDocs.Diagrams.Ui.Queries;

    public class Test
    {
        private readonly IEventPublisher<Test> publisher;

        private IEnumerable<IExecutableAction> actions;        

        public Test(string name, IEnumerable<IExecutableAction> actions, IQuery query, IEventPublisherFactory publisherFactory)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            if (publisherFactory == null)
            {
                throw new ArgumentNullException(nameof(publisherFactory));
            }

            this.Name = name;
            this.actions = actions;
            this.Query = query;
            this.publisher = publisherFactory.Create<Test>();
        }

        public string Name { get; }

        public IEnumerable<IExecutableAction> Actions => this.actions ?? (this.actions = Enumerable.Empty<IExecutableAction>());

        public IQuery Query { get; }        

        public bool Execute()
        {
            foreach (var action in this.Actions)
            {
                this.publisher.Publish(new ActionExecutionEvent(action));
                this.publisher.Publish(new CommandExecutionEvent(action.Command));
                action.Command.Execute();
            }

            this.publisher.Publish(new QueryExecutionEvent(this.Query));
            return this.Query.Execute();
        }
    }
}