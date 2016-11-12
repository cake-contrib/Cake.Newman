using Cake.Core;
using Cake.Core.IO;

namespace Cake.Newman.Reporters
{
    /// <summary>
    ///     Settings for the CLI Reporter
    /// </summary>
    public class CLIReporterSettings : IReporterSettings
    {
        /// <summary>
        ///     The CLI reporter is internally disabled and you see no output to terminal.
        /// </summary>
        public bool Silent { get; set; }

        /// <summary>
        ///     The statistical summary table is not shown.
        /// </summary>
        public bool NoSummary { get; set; }

        /// <summary>
        ///     This prevents the run failures from being separately printed.
        /// </summary>
        /// <remarks>Defaults to <c>true</c></remarks>
        public bool SeparateFailures { get; set; } = true;

        /// <summary>
        ///     This turns off the request-wise output as they happen.
        /// </summary>
        public bool NoAssertions { get; set; }

        /// <summary>
        ///     This turns off the output of console.log (and other console calls) from collection's scripts.
        /// </summary>
        public bool NoConsole { get; set; }

        /// <summary>
        ///     Outputs the reporter-specific settings to include in the invocation
        /// </summary>
        /// <returns>A string to be appended to the run command.</returns>
        public void RenderOptions(ProcessArgumentBuilder args)
        {
            if (Silent) args.Append(ReporterArgumentNames.CLI.Silent);
            if (NoSummary) args.Append(ReporterArgumentNames.CLI.NoSummary);
            if (!SeparateFailures) args.Append(ReporterArgumentNames.CLI.NoFailures);
            if (NoAssertions) args.Append(ReporterArgumentNames.CLI.NoAssertions);
            if (NoConsole) args.Append(ReporterArgumentNames.CLI.NoConsole);
        }
    }
}