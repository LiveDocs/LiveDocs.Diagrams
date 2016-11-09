namespace LiveDocs.Diagrams.Graph.Executable.Events
{
    using System;

    using LiveDocs.Diagrams.Graph.Executable.Models;
    using LiveDocs.Diagrams.Graph.Models;

    public class PathExecutionEvent : IEvent
    {        
        public PathExecutionEvent(Path<Guid, IState, ITransition> path, int pathNumber, int totalPaths)
        {            
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            this.Path = path;
            this.PathNumber = pathNumber;
            this.TotalPaths = totalPaths;
        }        

        public Path<Guid, IState, ITransition> Path { get; }

        public int PathNumber { get; }

        public int TotalPaths { get; }

        public string Title => $"Executing path ({this.PathNumber}/{this.TotalPaths}): {this.Path}";
    }
}