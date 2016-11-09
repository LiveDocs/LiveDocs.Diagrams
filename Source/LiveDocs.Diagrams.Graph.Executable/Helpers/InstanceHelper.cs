namespace LiveDocs.Diagrams.Graph.Executable.Helpers
{
    using System;
    using System.Linq;

    internal static class InstanceHelper
    {
        public static TInstance CreateInstance<TInstance>() where TInstance : class
        {
            var parameters = typeof(TInstance)
                .GetConstructors()
                .Single()
                .GetParameters()
                .Select(p => (object)null)
                .ToArray();

            return Activator.CreateInstance(typeof(TInstance), parameters) as TInstance;
        }
    }
}