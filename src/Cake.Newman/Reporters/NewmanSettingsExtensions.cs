using System;
using Cake.Core.IO;

namespace Cake.Newman.Reporters
{
    public static class NewmanSettingsExtensions
    {
        public static NewmanSettings UseJsonReporter(this NewmanSettings settings)
        {
            settings.Reporters.Add("json", null);
            return settings;
        }

        public static NewmanSettings UseJsonReporter(this NewmanSettings settings, FilePath outputFile)
        {
            settings.Reporters.Add("json", new JsonReporterSettings {OutputFile = outputFile});
            return settings;
        }

        public static NewmanSettings UseHtmlReporter(this NewmanSettings settings)
        {
            settings.Reporters.Add("html", null);
            return settings;
        }

        public static NewmanSettings UseHtmlReporter(this NewmanSettings settings,
            Action<HtmlReporterSettings> configure)
        {
            var html = new HtmlReporterSettings();
            configure?.Invoke(html);
            settings.Reporters.Add("html", html);
            return settings;
        }

        public static NewmanSettings UseJUnitReporter(this NewmanSettings settings)
        {
            settings.Reporters.Add("junit", null);
            return settings;
        }

        public static NewmanSettings UseJUnitReporter(this NewmanSettings settings, FilePath outputFile)
        {
            settings.Reporters.Add("junit", new JUnitReporterSettings {OutputFile = outputFile});
            return settings;
        }

        public static NewmanSettings UseCLIReporter(this NewmanSettings settings)
        {
            settings.Reporters.Add("cli", null);
            return settings;
        }

        public static NewmanSettings UseCLIReporter(this NewmanSettings settings, Action<CLIReporterSettings> configure)
        {
            var cli = new CLIReporterSettings();
            configure?.Invoke(cli);
            settings.Reporters.Add("cli", cli);
            return settings;
        }
    }
}