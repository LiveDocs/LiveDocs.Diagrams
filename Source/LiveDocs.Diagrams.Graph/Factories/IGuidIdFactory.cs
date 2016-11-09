namespace LiveDocs.Diagrams.Graph.Factories
{
    using System;

    public interface IGuidIdFactory<in TValue>
    {
        Guid GetOrAdd(TValue value);
    }
}