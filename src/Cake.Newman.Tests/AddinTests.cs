using System;
using Cake.Testing;
using Xunit;
using FluentAssertions;
using Cake.Core;
using Cake.Core.IO;
using System.IO;

namespace Cake.Newman.Tests
{
    public sealed class AddinTests
    {
        [Theory]
        [InlineData("./tools/newman.exe", "/Working/tools/newman.exe")]
        public void ShouldUseExecutableFromToolPathIfProvided(string toolPath, string expected)
        {
            // Given
            var fixture = new NewmanFixture();
            fixture.Settings.ToolPath = toolPath;
            fixture.GivenSettingsToolPathExist();

            // When
            var result = fixture.Run();

            // Then
            result.Path.FullPath.Should().Be(expected);
        }

        [Fact]
        public void ShouldFailOnNullContext()
        {
            // Given
            ICakeContext ctx = null;
            FilePath inputPath = "./collection.json";

            // When
            var ex = Record.Exception(() => ctx.RunCollection(inputPath));

            // Then
            ex.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public void ShouldFindExecutableIfToolPathNotProvided()
        {
            // Given
            var fixture = new NewmanFixture();
            // When
            var result = fixture.Run();
            // Then
            result.Path.FullPath.Should().Be("/Working/tools/newman");
        }

        [Fact]
        public void ShouldThrowIfExecutableWasNotFound()
        {
            // Given
            var fixture = new NewmanFixture();
            fixture.GivenDefaultToolDoNotExist();
            // When
            var action = new Action(() => fixture.Run());
            // Then
            action.ShouldThrow<CakeException>().WithMessage("Newman: Could not locate executable.");
        }

        [Fact]
        public void ShouldThrowIfProcessHasANonZeroExitCode()
        {
            // Given
            var fixture = new NewmanFixture();
            fixture.GivenProcessExitsWithCode(1);

            // When
            var action = new Action(() => fixture.Run());

            // Then
            action.ShouldThrow<CakeException>()
                .WithMessage("Newman: Process returned an error (exit code 1).");
        }

        [Fact]
        public void ShouldThrowIfProcessWasNotStarted()
        {
            // Given
            var fixture = new NewmanFixture();
            fixture.GivenProcessCannotStart();
            var action = new Action(() => fixture.Run());
            action.ShouldThrow<CakeException>().WithMessage("Newman: Process was not started.");
        }

        [Fact]
        public void ShouldThrowIfFileDoesNotExist()
        {
            // Given
            var fixture = new NewmanFixture();
            fixture.InputFile = "./nonexistent.json";

            // When
            Action action = () => fixture.Run();

            // Then
            action.ShouldThrow<FileNotFoundException>().WithMessage("nonexistent.json", "input file doesn't exist");
        }

        [Fact]
        public void ShouldUseSpecifiedCollectionFile()
        {
            // Given
            var fixture = new NewmanFixture();
            fixture.InputFile = "./custom-collection.json";
            fixture.FileSystem.CreateFile(fixture.InputFile);

            // When
            var result = fixture.Run();

            // Then
            result.Args.Should().Be("run custom-collection.json", "provided file is specified");
        }
    }
}