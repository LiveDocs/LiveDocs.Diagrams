namespace LiveDocs.Diagrams.Graph.Executable.Enums
{
    internal enum PathResolverState
    {
        None = 0,

        Start,
        
        Forward,

        Backward,

        PathComplete,

        Complete
    }
}