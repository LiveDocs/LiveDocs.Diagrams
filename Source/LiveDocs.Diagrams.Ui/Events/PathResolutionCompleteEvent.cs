namespace LiveDocs.Diagrams.Ui.Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using LiveDocs.Diagrams.Graph.Model;
    using LiveDocs.Diagrams.Ui.Models;

    public class PathResolutionCompleteEvent : IEvent
    {
        private IEnumerable<Path<IState, ITransition>> paths;

        public PathResolutionCompleteEvent(IEnumerable<Path<IState, ITransition>> paths)
        {
            if (paths == null)
            {
                throw new ArgumentNullException(nameof(paths));
            }

            this.paths = paths;
        }

        public IEnumerable<Path<IState, ITransition>> Paths => this.paths ?? (this.paths = Enumerable.Empty<Path<IState, ITransition>>());

        public string Title => $"Resolved the following {this.Paths.Count()} path(s): {Environment.NewLine}{string.Join(Environment.NewLine, this.Paths)}";
    }
}