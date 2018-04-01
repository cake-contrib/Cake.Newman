#tool "GitVersion.CommandLine"
#addin "Cake.DocFx"
#tool "docfx.console"
#tool "OpenCover"
#tool "nuget:?package=ReportGenerator"

#load "helpers.cake"

///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument<string>("target", "Default");
var configuration = Argument<string>("configuration", "Release");
var framework = Argument<string>("framework", "net462,netstandard2.0");

///////////////////////////////////////////////////////////////////////////////
// GLOBAL VARIABLES
///////////////////////////////////////////////////////////////////////////////

var solutionPath = File("./src/Cake.Newman.sln");
var solution = ParseSolution(solutionPath);
var projects = solution.Projects.Where(p => p.Type != "{2150E333-8FDC-42A3-9474-1A3956D46DE8}");
var projectPaths = projects.Select(p => p.Path.GetDirectory());
var frameworks = GetFrameworks(framework);
var testAssemblies = projects.Where(p => p.Name.Contains(".Tests"));
var artifacts = "./dist/";
var testResultsPath = MakeAbsolute(Directory(artifacts + "./test-results/"));
GitVersion versionInfo = null;

///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////

Setup(ctx =>
{
	// Executed BEFORE the first task.
	Information("Running tasks...");
	versionInfo = GitVersion();
	Information("Building for version {0}", versionInfo.FullSemVer);
	Information("Building against '{0}'", framework);
});

Teardown(ctx =>
{
	// Executed AFTER the last task.
	Information("Finished running tasks.");
});

///////////////////////////////////////////////////////////////////////////////
// TASK DEFINITIONS
///////////////////////////////////////////////////////////////////////////////

Task("Clean")
	.Does(() =>
{
	// Clean solution directories.
	foreach(var path in projectPaths)
	{
		Information("Cleaning {0}", path);
		CleanDirectories(path + "/**/bin/" + configuration);
		CleanDirectories(path + "/**/obj/" + configuration);
	}
	Information("Cleaning common files...");
	CleanDirectory(artifacts);
	DeleteFiles(GetFiles("./*.temp.nuspec"));
});

Task("Restore")
	.Does(() =>
{
	// Restore all NuGet packages.
	Information("Restoring solution...");
	//NuGetRestore(solutionPath);
	foreach(var project in projects) {
		DotNetCoreRestore(project.Path.GetDirectory() + $"/{project.Name}.csproj");
	}
});

Task("Build")
	.IsDependentOn("Clean")
	.IsDependentOn("Restore")
	.Does(() =>
{
	Information("Building solution...");
	CreateDirectory(artifacts + "build/");
	foreach(var project in projects) {
		foreach(var f in frameworks) {
			//CreateDirectory(artifacts + "build/" + f);
			DotNetCoreBuild(project.Path.GetDirectory().FullPath, new DotNetCoreBuildSettings {
				//Framework = f,
				Configuration = configuration,
				//OutputDirectory = artifacts + "build/" + configuration + "/" + f
			});
		}
	}
});

Task("Post-Build")
	.IsDependentOn("Build")
	.Does(() => {
		foreach (var project in projects) {
			CopyDirectory(project.Path.GetDirectory() + "/bin/" + configuration, artifacts + "build/" + project.Name);
		}
	});

Task("Generate-Docs").Does(() => {
	DocFxBuild("./docfx/docfx.json");
	Zip("./docfx/_site/", artifacts + "/docfx.zip");
});

Task("Run-Unit-Tests")
	.IsDependentOn("Build")
	.Does(() =>
{
	CreateDirectory(testResultsPath);
	CreateDirectory(testResultsPath + "/coverage");
	Action<ICakeContext> testAction = ctx => ctx.DotNetCoreTest("./src/Cake.Newman.Tests", new DotNetCoreTestSettings {
		NoBuild = true,
		Configuration = configuration,
		ArgumentCustomization = args => args.AppendSwitchQuoted("--logger", "trx;LogFileName="+testResultsPath + "/test-results.xml")
	});
	OpenCover(testAction,
		testResultsPath + "/coverage.xml",
		new OpenCoverSettings {
			ReturnTargetCodeOffset = 0,
			ArgumentCustomization = args => args.Append("-mergeoutput")
		}
		.WithFilter("+[Cake.Newman]*")
		.ExcludeByAttribute("*.ExcludeFromCodeCoverage*")
		.ExcludeByFile("*/*Designer.cs;*/*.g.cs;*/*.g.i.cs"));
	ReportGenerator(testResultsPath + "/coverage.xml", testResultsPath + "/coverage");
});

Task("NuGet")
	.IsDependentOn("Post-Build")
//	.IsDependentOn("Copy-Core-Dependencies")
	.IsDependentOn("Run-Unit-Tests")
	.Does(() => {
		CreateDirectory(artifacts + "package/");
		Information("Building NuGet package");
		var nuspecFiles = GetFiles("./*.nuspec");
		var versionNotes = ParseAllReleaseNotes("./ReleaseNotes.md").FirstOrDefault(v => v.Version.ToString() == versionInfo.MajorMinorPatch);
		var content = GetContent(frameworks, artifacts + "build/Cake.Newman/", "/Cake.Newman");
		NuGetPack(nuspecFiles, new NuGetPackSettings() {
			Version = versionInfo.NuGetVersionV2,
			ReleaseNotes = versionNotes != null ? versionNotes.Notes.ToList() : new List<string>(),
			OutputDirectory = artifacts + "/package",
			Files = content,
			//KeepTemporaryNuSpecFile = true
			});
	});

///////////////////////////////////////////////////////////////////////////////
// TARGETS
///////////////////////////////////////////////////////////////////////////////

Task("Default")
	.IsDependentOn("NuGet")
	.IsDependentOn("Generate-Docs");

///////////////////////////////////////////////////////////////////////////////
// EXECUTION
///////////////////////////////////////////////////////////////////////////////

RunTarget(target);