namespace Cake.Newman.Reporters
{
    internal static class ReporterArgumentNames
    {
        internal static class CLI
        {
            internal const string Silent = "--reporter-cli-silent";
            internal const string NoSummary = "--reporter-cli-no-summary";
            internal const string NoFailures = "--reporter-cli-no-failures";
            internal const string NoAssertions = "--reporter-cli-no-assertions";
            internal const string NoConsole = "--reporter-cli-no-console";
        }

        internal static class Json
        {
            internal const string Export = "--reporter-json-export";
        }

        internal static class Html
        {
            internal const string Export = "--reporter-html-export";
            internal const string Template = "--reporter-html-template";
        }

        internal static class JUnit
        {
            internal const string Export = "--reporter-junit-export";
        }
    }
}