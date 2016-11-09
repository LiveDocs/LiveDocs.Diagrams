namespace LiveDocs.Diagrams.Graph.Executable.Events
{
    using System;

    using LiveDocs.Diagrams.Graph.Executable.Models;

    public class ActionExecutionEvent : IEvent
    {        
        public ActionExecutionEvent(IAction action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            this.Action = action;
        }

        public IAction Action { get; }

        public string Title => $"{this.Action.Name}";
    }
}