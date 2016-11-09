namespace LiveDocs.Diagrams.Graph.Executable.Events
{
    using System;

    using LiveDocs.Diagrams.Graph.Executable.Queries;

    public class QueryExecutionEvent : IEvent
    {
        public QueryExecutionEvent(IQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            this.Query = query;
        }

        public IQuery Query { get; }

        public string Title => $"{this.Query.Name}";
    }
}