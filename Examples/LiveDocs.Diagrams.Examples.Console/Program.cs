namespace LiveDocs.Diagrams.Examples.Console
{
    using System;

    using LiveDocs.Diagrams.Ui.Builders;
    using LiveDocs.Diagrams.Ui.Models;
    using LiveDocs.Diagrams.Ui.Processors;

    using Action = LiveDocs.Diagrams.Ui.Models.Action;

    class Program
    {
        static void Main(string[] args)
        {
            var loginScreen = new Screen("Login");
            var validCredentials = new Decision("Valid Credentials?");

            var uiFlow = new UiFlowBuilder()
                .FromStartTo(loginScreen).Via(new Action("Navigate"))
                .From(loginScreen).To(validCredentials).Via(new Action("Submit"))
                .From(validCredentials).To(new Screen("Login Error")).Via(new Action("No"))
                .From(validCredentials).To(new Screen("Welcome")).Via(new Action("Yes"))
                .Build();

            var mermaidOutput = new MermaidProcessor().Process(uiFlow.ToGraph());
            Console.WriteLine(mermaidOutput);
        }
    }
}
