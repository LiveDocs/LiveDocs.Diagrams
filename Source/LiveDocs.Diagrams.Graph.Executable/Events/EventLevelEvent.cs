namespace LiveDocs.Diagrams.Graph.Executable.Events
{
    using System;

    public class EventLevelEvent : IEvent
    {
        private readonly int messageIndentation;

        public EventLevelEvent(IEvent @event, int messageIndentation)
        {            
            if (@event == null)
            {
                throw new ArgumentNullException(nameof(@event));
            }

            this.Event = @event;
            this.messageIndentation = messageIndentation;
        }

        public IEvent Event { get; }

        public string Title => $"{new string('\t', this.messageIndentation)}{this.Event.Title}";
    }
}