using Cake.Core.IO;

namespace Cake.Newman.Reporters
{
    /// <summary>
    ///     Represents reporter-specific settings
    /// </summary>
    public interface IReporterSettings
    {
        /// <summary>
        ///     Outputs the reporter-specific settings to include in the invocation
        /// </summary>
        /// <returns>A string to be appended to the run command.</returns>
        void RenderOptions(ProcessArgumentBuilder args);
    }
}