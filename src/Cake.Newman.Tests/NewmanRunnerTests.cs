using System;
using FluentAssertions;
using Xunit;

namespace Cake.Newman.Tests
{
    public class NewmanRunnerTests
    {
        [Fact]
        public void ShouldThrowOnNullCollectionFile()
        {
            // Given
            var fixture = new NewmanFixture();
            fixture.InputFile = null;

            // When
            Action action = () => fixture.Run();

            // Then
            action.ShouldThrow<ArgumentNullException>().WhereMessageContains("collectionFile", "null collection file provided");
        }

        [Fact]
        public void ShouldThrowOnNullSettings()
        {
            // Given
            var fixture = new NewmanFixture();
            fixture.Settings = null;

            // When
            Action action = () => fixture.Run();

            // Then
            action.ShouldThrow<ArgumentNullException>().WhereMessageContains("settings", "null settings object provided");
        }
    }
}
