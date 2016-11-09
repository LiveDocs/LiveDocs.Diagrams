namespace LiveDocs.Diagrams.Selenium.Builders
{
    using System;

    using LiveDocs.Diagrams.Graph.Executable.Models;
    using LiveDocs.Diagrams.Selenium.Models;    

    public interface ISeleniumFlowBuilderTo
    {
        ISeleniumFlowBuilder Via<TAction>() where TAction : class, IAction, ISeleniumCommandable;

        ISeleniumFlowBuilder Via<TAction>(TAction action) where TAction : class, IAction, ISeleniumCommandable;

        ISeleniumFlowBuilder Via(Func<ISeleniumQueryable, ISeleniumQueryable, ISeleniumCommandable> commandFactory);
    }
}
