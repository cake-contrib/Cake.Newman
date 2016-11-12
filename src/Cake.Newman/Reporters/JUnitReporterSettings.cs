using Cake.Core;
using Cake.Core.IO;

namespace Cake.Newman.Reporters
{
    /// <summary>
    ///     Settings for the JUnit reporter
    /// </summary>
    public class JUnitReporterSettings : IReporterSettings
    {
        /// <summary>
        ///     Path where the output XML file will be written to disk.
        /// </summary>
        /// <remarks>
        ///     If not specified, the file will be written to newman/ in the current working directory.
        /// </remarks>
        public FilePath OutputFile { get; set; }

        /// <summary>
        ///     Outputs the reporter-specific settings to include in the invocation
        /// </summary>
        /// <returns>A string to be appended to the run command.</returns>
        public void RenderOptions(ProcessArgumentBuilder args)
        {
            if (OutputFile != null) args.AppendSwitchQuoted(ReporterArgumentNames.JUnit.Export, OutputFile.FullPath);
        }
    }
}