namespace LiveDocs.Diagrams.Ui.Models
{
    using System;

    public class Transition : ITransition
    {        
        public Transition(IState source, IState target, IAction action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            this.Id = Guid.NewGuid();            
            this.Source = source;
            this.Target = target;
            this.Action = action;
        }

        public Guid Id { get; }        

        public IState Source { get; }
        
        public IState Target { get; }

        public IAction Action { get; }
    }
}