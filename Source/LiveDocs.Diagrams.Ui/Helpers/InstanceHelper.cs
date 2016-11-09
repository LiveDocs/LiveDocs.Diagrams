namespace LiveDocs.Diagrams.Ui.Helpers
{
    using System;
    using System.Linq;

    internal static class InstanceHelper
    {
        public static T CreateInstance<T>() where T : class
        {
            var parameters = typeof(T)
                .GetConstructors()
                .Single()
                .GetParameters()
                .Select(p => (object)null)
                .ToArray();

            return Activator.CreateInstance(typeof(T), parameters) as T;
        }
    }
}