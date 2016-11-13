using System;
using Cake.Core.IO;

namespace Cake.Newman.Reporters
{
    /// <summary>
    /// Extension methods for the <see cref="NewmanSettings"/> class for working with reporters.
    /// </summary>
    public static class NewmanSettingsExtensions
    {
        /// <summary>
        /// Adds the JSON reporter to this run.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The updated settings.</returns>
        public static NewmanSettings UseJsonReporter(this NewmanSettings settings)
        {
            settings.Reporters.Add("json", null);
            return settings;
        }

        /// <summary>
        /// Adds the JSON reporter to this run, exporting results to the specified file.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="outputFile">The path to the output file. Equivalent to <c>--reporter-json-export</c></param>
        /// <returns>The updated settings.</returns>
        public static NewmanSettings UseJsonReporter(this NewmanSettings settings, FilePath outputFile)
        {
            settings.Reporters.Add("json", new JsonReporterSettings {OutputFile = outputFile});
            return settings;
        }

        /// <summary>
        /// Adds the HTML reporter to this run.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The updated settings.</returns>
        public static NewmanSettings UseHtmlReporter(this NewmanSettings settings)
        {
            settings.Reporters.Add("html", null);
            return settings;
        }

        /// <summary>
        /// Adds the HTML reporter to this run, using the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="configure">Action to configure the HTML reporter.</param>
        /// <returns>The updated settings.</returns>
        public static NewmanSettings UseHtmlReporter(this NewmanSettings settings,
            Action<HtmlReporterSettings> configure)
        {
            var html = new HtmlReporterSettings();
            configure?.Invoke(html);
            settings.Reporters.Add("html", html);
            return settings;
        }

        /// <summary>
        /// Adds the JUnit/XML reporter to this run.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The updated settings.</returns>
        public static NewmanSettings UseJUnitReporter(this NewmanSettings settings)
        {
            settings.Reporters.Add("junit", null);
            return settings;
        }

        /// <summary>
        /// Adds the JUnit/XML reporter to this run, exporting results to the specified file.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="outputFile">The path to the output file. Equivalent to <c>--reporter-junit-export</c></param>
        /// <returns>The updated settings.</returns>
        public static NewmanSettings UseJUnitReporter(this NewmanSettings settings, FilePath outputFile)
        {
            settings.Reporters.Add("junit", new JUnitReporterSettings {OutputFile = outputFile});
            return settings;
        }

        /// <summary>
        /// Adds the CLI reporter to this run.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The updated settings.</returns>
        public static NewmanSettings UseCLIReporter(this NewmanSettings settings)
        {
            settings.Reporters.Add("cli", null);
            return settings;
        }

        /// <summary>
        /// Adds the CLI reporter to this run, using the specifid settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="configure">Action to configure the CLI reporter.</param>
        /// <returns>The updated settings.</returns>
        public static NewmanSettings UseCLIReporter(this NewmanSettings settings, Action<CLIReporterSettings> configure)
        {
            var cli = new CLIReporterSettings();
            configure?.Invoke(cli);
            settings.Reporters.Add("cli", cli);
            return settings;
        }
    }
}