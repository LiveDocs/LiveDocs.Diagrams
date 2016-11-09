namespace LiveDocs.Diagrams.Graph.Executable.Services
{
    using System;

    using LiveDocs.Diagrams.Graph.Executable.Models;
    using LiveDocs.Diagrams.Graph.Executable.Publishing;
    using LiveDocs.Diagrams.Graph.Models;

    public interface IPathTestStrategy<TVertex, TEdge>
        where TVertex : class, IState
        where TEdge : class, IEdge<TVertex>
    {
        Test GetTest(Path<Guid, IState, TEdge> path, IEventPublisherFactory publisherFactory);
    }
}