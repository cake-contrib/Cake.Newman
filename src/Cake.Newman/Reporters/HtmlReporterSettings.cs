using Cake.Core;
using Cake.Core.IO;

namespace Cake.Newman.Reporters
{
    /// <summary>
    ///     Settings for the HTML reporter.
    /// </summary>
    public class HtmlReporterSettings : IReporterSettings
    {
        /// <summary>
        ///     Path where the output HTML file will be written to disk.
        /// </summary>
        /// <remarks>
        ///     If not specified, the file will be written to newman/ in the current working directory.
        /// </remarks>
        public FilePath OutputFile { get; set; }

        /// <summary>
        ///     Path to the custom template which will be used to render the HTML report.
        /// </summary>
        /// <remarks>
        ///     This option depends on --reporter html and --reporter-html-export being present in the run command.
        /// </remarks>
        public FilePath TemplateFile { get; set; }

        /// <summary>
        ///     Outputs the reporter-specific settings to include in the invocation
        /// </summary>
        /// <returns>A string to be appended to the run command.</returns>
        public void RenderOptions(ProcessArgumentBuilder args)
        {
            if (OutputFile != null) args.AppendSwitchQuoted(ReporterArgumentNames.Html.Export, OutputFile.FullPath);
            if (TemplateFile != null)
                args.AppendSwitchQuoted(ReporterArgumentNames.Html.Template, TemplateFile.FullPath);
        }
    }
}