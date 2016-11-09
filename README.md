[![NuGet](https://img.shields.io/nuget/v/LiveDocs.Diagrams.svg)](https://www.nuget.org/packages/LiveDocs.Diagrams/)

# Installation

LiveDocs.Diagrams is available on NuGet.

To build UI flow charts:

```
install-package LiveDocs.Diagrams
```

To build UI flow charts which run [Selenium](http://docs.seleniumhq.org/) tests:

```
install-package LiveDocs.Diagrams.Selenium
```

# Getting Started

To start defining a flow chart, you can use the provided `State`, `Action`, and `Decision` types with the `FlowBuilder`:

```
var loginScreen = new State("Login");
var validCredentials = new Decision("Valid Credentials?");

var flow = new FlowBuilder()
    .FromStartTo(loginScreen).Via(new Action("Navigate"))
    .From(loginScreen).To(validCredentials).Via(new Action("Submit"))
    .From(validCredentials).To(new State("Login Error")).Via(new Action("No"))
    .From(validCredentials).To(new State("Welcome")).Via(new Action("Yes"))
    .Build();
```

We can output the flow as a [Mermaid](https://knsv.github.io/mermaid/) flowchart using the provided `MermaidProcessor`:

```
var mermaidOutput = new MermaidProcessor().Process(flow.ToGraph());
Console.WriteLine(mermaidOutput);
```

The mermaid output from the processor can be used with the Mermaid library or the [live editor](http://knsv.github.io/mermaid/live_editor/) to generate an SVG version of the flow.

# Roadmap

- [ ] Switch to ID to signify unique screens/actions, rather than references
- [ ] Implement Action and Screen types that have id constructors
- [ ] Run individual paths, specify array of types or path string
- [ ] Run multiple browsers (IWebDriverFactory)
- [ ] Continue or exit on exception
- [ ] Success rate fail/pass test
- [ ] Detail levels, output to mermaid takes detail level
- [ ] Subflows
- [ ] HTTP request/response details on each screen
- [ ] HTTP request/response logging as path is executed
- [ ] Screenshot of each screen on transition (query) complete
- [ ] Make wait on screen query implicit in the test runner rather than part of the actions
- [ ] Automatic flows based on property validation attributes
- [ ] Documentation site
