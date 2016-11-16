using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Cake.Newman.Reporters;
using FluentAssertions;

namespace Cake.Newman.Tests.Reporters
{
    public class NewmanReporterTests
    {
        [Fact]
        public void ShouldAddMultipleReportersWhenInvoked()
        {
            // Given
            var fixture = new NewmanFixture(s => s.UseCLIReporter().UseJsonReporter().UseHtmlReporter().UseJUnitReporter());

            // When
            var result = fixture.Run();

            // Then
            result.Args().Should().Be("--reporters cli,json,html,junit");
        }

        public sealed class TheCLIReporter
        {
            [Fact]
            public void ShouldAddReporterWhenInvoked()
            {
                // Given
                var fixture = new NewmanFixture(s => s.UseCLIReporter());

                // When
                var result = fixture.Run();

                // Then
                result.Args().Should().Be("--reporters cli");
            }

            [Fact]
            public void ShouldSpecifyNoOptionsByDefault()
            {
                // Given
                var fixture = new NewmanFixture();
                fixture.Settings.Reporters.Add("cli", new CLIReporterSettings());

                // When
                var result = fixture.Run();

                // Then
                result.Args().Should().Be("--reporters cli");
            }

            [Fact]
            public void ShouldNotFailOnNullAction()
            {
                // Given
                var fixture = new NewmanFixture(s => s.UseCLIReporter(null));

                // When
                var result = fixture.Run();

                // Then
                result.Args().Should().Be("--reporters cli");
            }

            [Fact]
            public void ShouldSpecifySilentWhenInvoked()
            {
                // Given
                var fixture = new NewmanFixture(s => s.UseCLIReporter(c => c.RunSilently()));

                // When
                var result = fixture.Run();

                // Then
                result.Args().Should().Be("--reporters cli --reporter-cli-silent", "the fluent interface adds reporter automatically");
            }

            [Fact]
            public void ShouldSpecifySilentWhenSet()
            {
                // Given
                var fixture = new NewmanFixture(s => s.UseCLIReporter(c =>
                {
                    c.Silent = true;
                }));

                // When
                var result = fixture.Run();

                // Then
                result.Args().Should().Be("--reporters cli --reporter-cli-silent");
            }

            [Fact]
            public void ShouldSpecifyNoSummaryWhenInvoked()
            {
                //Given
                var fixture = new NewmanFixture(s => s.UseCLIReporter(c => c.DisableSummary()));

                //When
                var result = fixture.Run();

                //Then
                result.Args().Should().Be("--reporters cli --reporter-cli-no-summary");
            }

            [Fact]
            public void ShouldspecifyNoSummaryWhenSet()
            {
                // Given
                var fixture = new NewmanFixture(s => s.UseCLIReporter(c =>
                {
                    c.NoSummary = true;
                }));

                // When
                var result = fixture.Run();

                // Then
                result.Args().Should().Be("--reporters cli --reporter-cli-no-summary");
            }

            [Fact]
            public void ShouldSpecifyNoFailuresWhenInvoked()
            {
                // Given
                var fixture = new NewmanFixture(s => s.UseCLIReporter(c => c.DisableSeparateFailures()));

                // When
                var result = fixture.Run();

                // Then
                result.Args().Should().Be("--reporters cli --reporter-cli-no-failures");
            }

            [Fact]
            public void ShouldSpecifyNoFailuresWhenSet()
            {
                // Given
                var fixture = new NewmanFixture(s => s.UseCLIReporter(c =>
                {
                    c.SeparateFailures = false;
                }));

                // When
                var result = fixture.Run();

                // Then
                result.Args().Should().Be("--reporters cli --reporter-cli-no-failures");
            }

            [Fact]
            public void ShouldSpecifyNoAssertionsWhenInvoked()
            {
                // Given
                var fixture = new NewmanFixture(s => s.UseCLIReporter(c => c.DisableAssertions()));

                // When
                var result = fixture.Run();

                // Then
                result.Args().Should().Be("--reporters cli --reporter-cli-no-assertions");
            }

            [Fact]
            public void ShouldSpecifyNoAssertionsWhenSet()
            {
                // Given
                var fixture = new NewmanFixture(s => s.UseCLIReporter(c =>
                {
                    c.NoAssertions = true;
                }));

                // When
                var result = fixture.Run();

                // Then
                result.Args().Should().Be("--reporters cli --reporter-cli-no-assertions");
            }

            [Fact]
            public void ShouldSpecifyNoConsoleWhenInvoked()
            {
                // Given
                var fixture = new NewmanFixture(s => s.UseCLIReporter(c => c.DisableConsoleOutput()));

                // When
                var result = fixture.Run();

                // Then
                result.Args().Should().Be("--reporters cli --reporter-cli-no-console");
            }

            [Fact]
            public void ShouldSpecifyNoConsoleWhenSet()
            {
                // Given
                var fixture = new NewmanFixture(s => s.UseCLIReporter(c =>
                {
                    c.NoConsole = true;
                }));

                // When
                var result = fixture.Run();

                // Then
                result.Args().Should().Be("--reporters cli --reporter-cli-no-console");
            }
        }

        public sealed class TheJsonReporter
        {
            [Fact]
            public void ShouldAddReporterWhenInvoked()
            {
                // Given
                var fixture = new NewmanFixture(s => s.UseJsonReporter());

                // When
                var result = fixture.Run();

                // Then
                result.Args().Should().Be("--reporters json");
            }

            [Fact]
            public void ShouldSpecifyNoOptionsByDefault()
            {
                // Given
                var fixture = new NewmanFixture();
                fixture.Settings.Reporters.Add("json", new JsonReporterSettings());

                // When
                var result = fixture.Run();

                // Then
                result.Args().Should().Be("--reporters json");
            }

            [Fact]
            public void ShouldSpecifyExportPathWhenInvoked()
            {
                // Given
                var fixture = new NewmanFixture(s => s.UseJsonReporter("./output-report.json"));

                // When
                var result = fixture.Run();

                // Then
                result.Args().Should().Be("--reporters json --reporter-json-export \"output-report.json\"");
            }
        }

        public sealed class TheHtmlReporter
        {
            [Fact]
            public void ShouldAddReporterWhenInvoked()
            {
                // Given
                var fixture = new NewmanFixture(s => s.UseHtmlReporter());

                // When
                var result = fixture.Run();

                // Then
                result.Args().Should().Be("--reporters html");
            }

            [Fact]
            public void ShouldSpecifyNoOptionsByDefault()
            {
                // Given
                var fixture = new NewmanFixture();
                fixture.Settings.Reporters.Add("html", new HtmlReporterSettings());

                // When
                var result = fixture.Run();

                // Then
                result.Args().Should().Be("--reporters html");
            }

            [Fact]
            public void ShouldNotFailOnNullAction()
            {
                // Given
                var fixture = new NewmanFixture(s => s.UseHtmlReporter(null));

                // When
                var result = fixture.Run();

                // Then
                result.Args().Should().Be("--reporters html");
            }

            [Fact]
            public void ShouldSpecifyExportPathWhenInvoked()
            {
                // Given
                var fixture = new NewmanFixture(s => s.UseHtmlReporter(h => h.UseOutputFile("./output-file.html")));

                // When
                var result = fixture.Run();

                // Then
                result.Args().Should().Be("--reporters html --reporter-html-export \"output-file.html\"");
            }

            [Fact]
            public void ShouldSpecifyExportPathWhenSet()
            {
                // Given
                var fixture = new NewmanFixture(s => s.UseHtmlReporter(h =>
                {
                    h.OutputFile = "./output-file.html";
                }));

                // When
                var result = fixture.Run();

                // Then
                result.Args().Should().Be("--reporters html --reporter-html-export \"output-file.html\"");
            }

            [Fact]
            public void ShouldSpecifyTemplatePathWhenInvoked()
            {
                // Given
                var fixture = new NewmanFixture(s => s.UseHtmlReporter(h => h.UseTemplateFile("./template-file.html")));

                // When
                var result = fixture.Run();

                // Then
                result.Args().Should().Be("--reporters html --reporter-html-template \"template-file.html\"");
            }

            [Fact]
            public void ShouldSpecifyTemplatePathWhenSet()
            {
                // Given
                var fixture = new NewmanFixture(s => s.UseHtmlReporter(h =>
                {
                    h.TemplateFile = "./template-file.html";
                }));

                // When
                var result = fixture.Run();

                // Then
                result.Args().Should().Be("--reporters html --reporter-html-template \"template-file.html\"");
            }
        }

        public sealed class TheJUnitReporter
        {
            [Fact]
            public void ShouldAddReporterWhenInvoked()
            {
                // Given
                var fixture = new NewmanFixture(s => s.UseJUnitReporter());

                // When
                var result = fixture.Run();

                // Then
                result.Args().Should().Be("--reporters junit");
            }

            [Fact]
            public void ShouldSpecifyNoOptionsByDefault()
            {
                // Given
                var fixture = new NewmanFixture();
                fixture.Settings.Reporters.Add("junit", new JUnitReporterSettings());

                // When
                var result = fixture.Run();

                // Then
                result.Args().Should().Be("--reporters junit");
            }

            [Fact]
            public void ShouldSpecifyExportPathWhenInvoked()
            {
                // Given
                var fixture = new NewmanFixture(s => s.UseJUnitReporter("./output-report.xml"));

                // When
                var result = fixture.Run();

                // Then
                result.Args().Should().Be("--reporters junit --reporter-junit-export \"output-report.xml\"");
            }
        }
    }
}
