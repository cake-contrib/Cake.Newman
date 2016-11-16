using Cake.Testing.Fixtures;
using FluentAssertions.Specialized;

namespace Cake.Newman.Tests
{
    internal static class TestExtensions
    {
        internal static string Args(this ToolFixtureResult result)
        {
            return result.Args.Replace("run collection.json ", string.Empty);
        }

        internal static ExceptionAssertions<T> WhereMessageContains<T>(this ExceptionAssertions<T> exception, string s) where T : System.Exception
        {
            exception.Where(e => e.Message.Contains(s));
            return exception;
        }

        internal static ExceptionAssertions<T> WhereMessageContains<T>(this ExceptionAssertions<T> exception, string s, string because) where T : System.Exception
        {
            exception.Where(e => e.Message.Contains(s), because);
            return exception;
        }
    }
}