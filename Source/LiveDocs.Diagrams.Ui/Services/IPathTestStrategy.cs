namespace LiveDocs.Diagrams.Ui.Services
{
    using LiveDocs.Diagrams.Graph.Model;
    using LiveDocs.Diagrams.Ui.Models;
    using LiveDocs.Diagrams.Ui.Publishing;

    public interface IPathTestStrategy<TVertex, TEdge>
        where TVertex : class, IState
        where TEdge : class, IEdge<TVertex>
    {
        Test GetTest(Path<IState, TEdge> path, IEventPublisherFactory publisherFactory);
    }
}