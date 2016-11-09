namespace LiveDocs.Diagrams.Graph.Executable.Queries
{
    using System.Collections.Generic;
    using System.Linq;

    public class CompositeAllQuery : IQuery
    {
        private IEnumerable<IQuery> queries;

        public CompositeAllQuery(params IQuery[] queries)
        {
            this.queries = queries;
        }

        private IEnumerable<IQuery> Queries => this.queries ?? (this.queries = Enumerable.Empty<IQuery>());

        public string Name => string.Join(", ", this.Queries.Select(c => c.Name));

        public bool Execute()
        {
            return this.Queries.All(query => query.Execute());
        }
    }
}