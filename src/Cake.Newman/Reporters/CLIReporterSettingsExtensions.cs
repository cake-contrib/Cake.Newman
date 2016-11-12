namespace Cake.Newman.Reporters
{
    /// <summary>
    ///     Extension methods for the <see cref="CLIReporterSettings" /> class.
    /// </summary>
    public static class CLIReporterSettingsExtensions
    {
        /// <summary>
        /// Disables the CLI reporter internally and no output is sent to the console
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The updated settings.</returns>
        public static CLIReporterSettings RunSilently(this CLIReporterSettings settings)
        {
            settings.Silent = true;
            return settings;
        }

        /// <summary>
        /// Disables the statistical summary table from being shown.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The updated settings.</returns>
        public static CLIReporterSettings DisableSummary(this CLIReporterSettings settings)
        {
            settings.NoSummary = true;
            return settings;
        }

        /// <summary>
        /// Prevents the run failures from being separately printed.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The updated settings.</returns>
        public static CLIReporterSettings DisableSeparateFailures(this CLIReporterSettings settings)
        {
            settings.SeparateFailures = false;
            return settings;
        }

        /// <summary>
        /// Turns off the request-wise output as they happen.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The updated settings.</returns>
        public static CLIReporterSettings DisableAssertions(this CLIReporterSettings settings)
        {
            settings.NoAssertions = true;
            return settings;
        }

        /// <summary>
        /// Turns off the output of <c>console.log</c> (and other console calls) from collection's scripts.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The updated settings.</returns>
        public static CLIReporterSettings DisableConsoleOutput(this CLIReporterSettings settings)
        {
            settings.NoConsole = true;
            return settings;
        }
    }
}