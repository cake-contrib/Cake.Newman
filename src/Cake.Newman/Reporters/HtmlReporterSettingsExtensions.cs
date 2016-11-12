using Cake.Core.IO;

namespace Cake.Newman.Reporters
{
    /// <summary>
    ///     Extension methods for the <see cref="HtmlReporterSettings" /> class.
    /// </summary>
    public static class HtmlReporterSettingsExtensions
    {
        /// <summary>
        /// Specify a path where the output HTML file will be written to disk.
        /// </summary>
        /// <remarks>
        /// Sets the <see cref="HtmlReporterSettings.OutputFile"/> property.</remarks>
        /// <param name="settings">The settings.</param>
        /// <param name="outputFile">The path for the output file to be written to.</param>
        /// <returns>The updated settings.</returns>
        public static HtmlReporterSettings UseOutputFile(this HtmlReporterSettings settings, FilePath outputFile)
        {
            settings.OutputFile = outputFile;
            return settings;
        }

        /// <summary>
        /// Specify a path to the custom template which will be used to render the HTML report. 
        /// </summary>
        /// <remarks>
        /// Sets the <see cref="HtmlReporterSettings.TemplateFile"/> property.</remarks>
        /// <param name="settings">The settings.</param>
        /// <param name="templateFile">The path for the template file to use.</param>
        /// <returns>The updated settings.</returns>
        public static HtmlReporterSettings UseTemplateFile(this HtmlReporterSettings settings, FilePath templateFile)
        {
            settings.TemplateFile = templateFile;
            return settings;
        }
    }
}