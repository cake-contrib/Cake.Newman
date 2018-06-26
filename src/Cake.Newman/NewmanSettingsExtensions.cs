using Cake.Core.IO;

namespace Cake.Newman
{
    /// <summary>
    /// Extension methods for the <see cref="NewmanSettings"/> class.
    /// </summary>
    public static class NewmanSettingsExtensions
    {
        /// <summary>
        ///     Disables SSL verification checks and allows self-signed SSL certificates.
        /// </summary>
        /// <remarks>This is an alias for <see cref="Insecure"/>.</remarks>
        /// <param name="settings">The settings.</param>
        /// <returns>The updated settings.</returns>
        public static NewmanSettings DisableStrictSSL(this NewmanSettings settings)
        {
            settings.DisableStrictSSL = true;
            return settings;
        }

        /// <summary>
        ///     Disables SSL verification checks and allows self-signed SSL certificates.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The updated settings.</returns>
        public static NewmanSettings Insecure(this NewmanSettings settings)
        {
            settings.DisableStrictSSL = true;
            return settings;
        }

        /// <summary>
        /// Specify whether or not to stop a collection run on encountering the first error.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The updated settings.</returns>
        public static NewmanSettings ExitOnFirstFailure(this NewmanSettings settings)
        {
            settings.ExitOnFirstFailure = true;
            return settings;
        }

        /// <summary>
        /// Prevents newman from automatically following 3XX redirect responses.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The updated settings.</returns>
        public static NewmanSettings IgnoreRedirects(this NewmanSettings settings)
        {
            settings.IgnoreRedirects = true;
            return settings;
        }

        /// <summary>
        /// Sets the time to wait for request responses.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="timeout">The time (in milliseconds)</param>
        /// <returns>The updated settings.</returns>
        public static NewmanSettings SetRequestTimeout(this NewmanSettings settings, int timeout)
        {
            settings.RequestTimeout = timeout;
            return settings;
        }

        /// <summary>
        /// Sets the time to wait for script to complete.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="timeout">The time (in milliseconds)</param>
        /// <returns>The updated settings.</returns>
        public static NewmanSettings SetScriptTimeout(this NewmanSettings settings, int timeout)
        {
            settings.ScriptTimeout = timeout;
            return settings;
        }

        /// <summary>
        /// Specify the extent of delay between requests (in milliseconds).
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="delay">The time (in milliseconds).</param>
        /// <returns>The updated settings.</returns>
        public static NewmanSettings SetRequestDelay(this NewmanSettings settings, int delay)
        {
            settings.RequestDelay = delay;
            return settings;
        }

        /// <summary>
        /// Specify the file where Newman will output the final global variables file before completing a run.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="globalsFile">The path to the output file.</param>
        /// <returns>The updated settings.</returns>
        public static NewmanSettings ExportGlobalsTo(this NewmanSettings settings, FilePath globalsFile)
        {
            settings.ExportGlobalsPath = globalsFile;
            return settings;
        }

        /// <summary>
        /// Specify the file where Newman will output the final collection file before completing a run.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="collectionFile">The path to the output file.</param>
        /// <returns>The updated settings.</returns>
        public static NewmanSettings ExportCollectionTo(this NewmanSettings settings, FilePath collectionFile)
        {
            settings.ExportCollectionPath = collectionFile;
            return settings;
        }

        /// <summary>
        /// Specify the file where Newman will output the final environment variables file before completing a run.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="environmentFile">The path to the ouput file.</param>
        /// <returns>The updated settings.</returns>
        public static NewmanSettings ExportEnvironmentTo(this NewmanSettings settings, FilePath environmentFile)
        {
            settings.ExportEnvironmentPath = environmentFile;
            return settings;
        }

        /// <summary>
        /// Run requests within only the specified folder in a collection.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="folder">The folder name to execute.</param>
        /// <returns>The updated settings.</returns>
        public static NewmanSettings RunOnlyFolder(this NewmanSettings settings, string folder)
        {
            settings.Folder = folder;
            return settings;
        }

        /// <summary>
        /// Specify the file path for global variables for the current execution.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="globalsFile">The path to the input variables file.</param>
        /// <returns>The updated settings.</returns>
        public static NewmanSettings WithGlobals(this NewmanSettings settings, FilePath globalsFile)
        {
            settings.GlobalVariablesFile = globalsFile;
            return settings;
        }
        /// <summary>
        /// Specify the file path for an environmentsfiel to use for the current execution.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="environmentFile">The path to the input environments file.</param>
        /// <returns>The updated settings.</returns>
        public static NewmanSettings WithEnvironment(this NewmanSettings settings, FilePath environmentFile)
        {
            settings.EnvironmentFile = environmentFile;
            return settings;
        }

        /// <summary>
        /// Specify the file path for an data file to use for the current execution.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="dataFile">The path to the input data file.</param>
        /// <returns>The updated settings.</returns>
        public static NewmanSettings WithData(this NewmanSettings settings, FilePath dataFile)
        {
            settings.DataFile = dataFile;
            return settings;
        }

        /// <summary>
        /// Sets the iteration count.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="iterationCount">Iteration count</param>
        /// <returns>The updated settings.</returns>
        public static NewmanSettings SetIterationCount(this NewmanSettings settings, int iterationCount)
        {
            settings.IterationCount = iterationCount;
            return settings;
        }
    }
}