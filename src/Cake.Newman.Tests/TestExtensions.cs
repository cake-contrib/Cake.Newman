using Cake.Testing.Fixtures;

namespace Cake.Newman.Tests {
    internal static class TestExtensions {
        internal static string Args(this ToolFixtureResult result) {
            return result.Args.Replace("run collection.json ", string.Empty);
        }
    }
}