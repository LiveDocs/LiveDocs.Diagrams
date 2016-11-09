namespace LiveDocs.Diagrams.Graph.Executable.Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using LiveDocs.Diagrams.Graph.Executable.Models;
    using LiveDocs.Diagrams.Graph.Models;

    public class PathResolutionCompleteEvent : IEvent
    {
        private IEnumerable<Path<Guid, IState, ITransition>> paths;

        public PathResolutionCompleteEvent(IEnumerable<Path<Guid, IState, ITransition>> paths)
        {
            if (paths == null)
            {
                throw new ArgumentNullException(nameof(paths));
            }

            this.paths = paths;
        }

        public IEnumerable<Path<Guid, IState, ITransition>> Paths => this.paths ?? (this.paths = Enumerable.Empty<Path<Guid, IState, ITransition>>());

        public string Title => $"Resolved the following {this.Paths.Count()} path(s): {Environment.NewLine}{string.Join(Environment.NewLine, this.Paths)}";
    }
}