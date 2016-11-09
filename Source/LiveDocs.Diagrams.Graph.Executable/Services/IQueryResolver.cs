namespace LiveDocs.Diagrams.Graph.Executable.Services
{
    using System;

    using LiveDocs.Diagrams.Graph.Executable.Queries;
    using LiveDocs.Diagrams.Graph.Models;

    public interface IQueryResolver
    {
        IQuery GetQuery(IVertex vertex);
    }
}