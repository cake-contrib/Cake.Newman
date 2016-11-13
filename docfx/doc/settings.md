# Settings

Since `newman` supports such a massive number of command line options, this addin includes a complex settings structure.

While it is possible to create the settings object 'manually', it is not recommended. In particular, working with reporters will be very difficult when creating the settings object directly. Instead, the addin provides a full set of extension methods as a fluent API. For example, the folllowing object code:

```csharp
var settings = new NewmanSettings()
{
    DisableStrictSSL = true,
    ExportCollectionPath = "./collection-export.json",
};
settings.Reporters.Add("json", new JsonReporterSettings()
{
    OutputFile = "./json-report.json"
});
RunCollection("./collection.json", settings);
```

can be replicated using the following fluent API code:

```csharp
RunCollection("./collection.json", s => 
    s.DisableStrictSSL()
    .ExportCollectionTo("./collection-export.json")
    .UseJsonReporter("./json-report.json"));
```

The complete extension methods are available in the Reference documentation (from the nav bar above), but a quick summary of all of the available settings is also included below.

```csharp
RunCollection("./collection.json", s => 
    s.DisableStrictSSL()
    .ExitOnFirstFailure()
    .IgnoreRedirects()
    .RunOnlyFolder("Tests")
    .SetRequestDelay(1000)
    .SetRequestTimeout(5000)
    .ExportCollectionTo("./export-collection.json")
    .ExportGlobalsTo("./export-globals.json")
    .ExportEnvironmentTo("./export-environments.json")
    .UseCLIReporter(c => 
        c.RunSilently()
        .DisableAssertions()
        .DisableConsoleOutput()
        .DisableSeparateFailures()
        .DisableSummary())
    .UseHtmlReporter(h =>
        h.UseOutputFile("./output-report.html")
        .UseTemplateFile("./template.html"))
    .UseJsonReporter("./output-report.json")
    .UseJUnitReporter("./output-report.xml"));
```