namespace LiveDocs.Diagrams.Selenium.Builders
{
    using System;

    using LiveDocs.Diagrams.Selenium.Models;

    public interface ISeleniumStartViaBuilder
    {
        ISeleniumFlowBuilder Via<TAction>() where TAction : class, ISeleniumCommandable;

        ISeleniumFlowBuilder Via(ISeleniumCommandable action);

        ISeleniumFlowBuilder Via(Func<ISeleniumQueryable, ISeleniumQueryable, ISeleniumCommandable> commandFactory);
    }
}