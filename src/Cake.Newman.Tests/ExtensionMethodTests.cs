using FluentAssertions;
using Xunit;

namespace Cake.Newman.Tests
{

    public sealed class ExtensionMethodTests
    {

        [Fact]
        public void ShouldSpecifyBailWhenInvoked()
        {
            // Given
            var fixture = new NewmanFixture(s => s.ExitOnFirstFailure());

            // When
            var result = fixture.Run();

            // Then
            result.Args().Should().Be("--bail");
        }

        [Fact]
        public void ShouldSpecifyIgnoreRedirectsWhenInvoked()
        {
            // Given
            var fixture = new NewmanFixture(s => s.IgnoreRedirects());

            // When
            var result = fixture.Run();

            // Then
            result.Args().Should().Be("--ignore-redirects");
        }

        [Fact]
        public void ShouldSpecifyInsecureWhenInvoked()
        {
            // Given
            var fixture = new NewmanFixture(s => s.DisableStrictSSL());

            // When
            var result = fixture.Run();

            // Then
            result.Args().Should().Be("--insecure");
        }

        [Fact]
        public void ShouldSetDelayWhenInvoked()
        {
            // Given
            var fixture = new NewmanFixture(s => s.SetRequestDelay(50));

            // When
            var result = fixture.Run();

            // Then
            result.Args().Should().Be("--delay-request 50");
        }

        [Fact]
        public void ShouldSetTimeoutWhenInvoked()
        {
            // Given
            var fixture = new NewmanFixture(s => s.SetRequestTimeout(25));

            // When
            var result = fixture.Run();

            // Then
            result.Args().Should().Be("--timeout-request 25");
        }

        [Fact]
        public void ShouldSetFolderWhenInvoked()
        {
            // Given
            var fixture = new NewmanFixture(s => s.RunOnlyFolder("Services"));

            // When
            var result = fixture.Run();

            // Then
            result.Args().Should().Be("--folder \"Services\"");
        }

        public sealed class TheExportMethods
        {
            [Fact]
            public void ShouldSetGlobalsExportWhenInvoked()
            {
                // Given
                var fixture = new NewmanFixture(s => s.ExportGlobalsTo("./globals.json"));

                // When
                var result = fixture.Run();

                // Then
                result.Args().Should().Be("--export-globals \"globals.json\"");
            }

            [Fact]
            public void ShouldSetEnvironmentsExportWhenInvoked()
            {
                // Given
                var fixture = new NewmanFixture(s => s.ExportEnvironmentTo("./environment.json"));

                // When
                var result = fixture.Run();

                // Then
                result.Args().Should().Be("--export-environment \"environment.json\"");
            }

            [Fact]
            public void ShouldSetCollectionExportWhenInvoked()
            {
                // Given
                var fixture = new NewmanFixture(s => s.ExportCollectionTo("./export.json"));

                // When
                var result = fixture.Run();

                // Then
                result.Args().Should().Be("--export-collection \"export.json\"");
            }
        }

        public sealed class ThePathTests
        {
            [Fact]
            public void ShouldSetGlobalsPathWhenInvoked()
            {
                // Given
                var fixture = new NewmanFixture(s => s.WithGlobals("./globals.json"));

                // When
                var result = fixture.Run();

                // Then
                result.Args().Should().Be("--globals \"globals.json\"");
            }

            [Fact]
            public void ShouldSetEnvironmentFilePathWhenInvoked() {
                // Given
                var fixture = new NewmanFixture(s => s.WithEnvironment("./environments.json"));

                // When
                var result = fixture.Run();

                // Then
                result.Args().Should().Be("--environment \"environments.json\"");
            }
        }
    }
}