namespace LiveDocs.Diagrams.Graph.Factories
{
    using System;
    using System.Collections.Generic;

    public class StringToGuidIdFactory : IGuidIdFactory<string>
    {
        private readonly IDictionary<string, Guid> guids;

        public Guid Id = Guid.NewGuid();

        public StringToGuidIdFactory()
        {
            this.guids = new Dictionary<string, Guid>();
        }

        public Guid GetOrAdd(string value)
        {
            if (this.guids.ContainsKey(value))
            {
                return this.guids[value];
            }

            var guid = Guid.NewGuid();
            this.guids.Add(value, guid);
            return guid;
        }
    }
}