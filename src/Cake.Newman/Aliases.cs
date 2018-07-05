using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;

namespace Cake.Newman
{
    /// <summary>
    /// <para>
    /// Contains functionality related to the <see href="https://github.com/postmanlabs/newman">Newman CLI</see>.
    /// </para>
    /// <para>In order to use the commands for this addin, you will need to include the following in your build.cake file to download and
    /// reference from NuGet.org:
    /// <code>
    /// #addin Cake.Newman
    /// #addin Cake.Npm
    /// </code>
    /// </para>
    /// <para>
    /// Postman needs the Newman npm package to run, or else the error 'Newman: executable not found' will be raised. You need to import
    /// the Postman package first. To do this, create a task and import the 'Postman' npm package using <see href="https://cakebuild.net/dsl/npm/">NpmInstall</see>.
    /// </para>
    /// </summary>
    [CakeAliasCategory("Postman")]
    [CakeNamespaceImport("Cake.Newman")]
    [CakeNamespaceImport("Cake.Newman.Reporters")]
    public static class NewmanAliases
    {
        /// <summary>
        /// Executes Newman against the given collection file, using all defaults.
        /// </summary>
        /// <param name="ctx">The context.</param>
        /// <param name="collectionFile">Path to the collection file.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// RunCollection("./collection.json");
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void RunCollection(this ICakeContext ctx, FilePath collectionFile)
        {
            if (ctx == null) throw new ArgumentNullException(nameof(ctx));
            if (collectionFile == null) throw new ArgumentNullException(nameof(collectionFile));
            var runner = new NewmanRunner(ctx.FileSystem, ctx.Environment, ctx.ProcessRunner, ctx.Tools, ctx.Log);
            runner.RunTool(collectionFile, new NewmanSettings());
        }

        /// <summary>
        /// Executes Newman against the given collection file, using all defaults.
        /// </summary>
        /// <param name="ctx">The context.</param>
        /// <param name="collectionFile">Path to the collection file.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// RunCollection("./collection.json", new NewmanSettings()
        ///     {
        ///         DisableStrictSSL = true,
        ///         ExportCollectionPath = "./collection-export.json",
        ///     });
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void RunCollection(this ICakeContext ctx, FilePath collectionFile, NewmanSettings settings)
        {
            if (ctx == null) throw new ArgumentNullException(nameof(ctx));
            if (collectionFile == null) throw new ArgumentNullException(nameof(collectionFile));
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            var runner = new NewmanRunner(ctx.FileSystem, ctx.Environment, ctx.ProcessRunner, ctx.Tools, ctx.Log);
            runner.RunTool(collectionFile, settings);
        }

        /// <summary>
        /// Executes Newman against the given collection file, using all defaults.
        /// </summary>
        /// <param name="ctx">The context.</param>
        /// <param name="collectionFile">Path to the collection file.</param>
        /// <param name="configure">The settings configurator.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// RunCollection("./collection.json", s => 
        ///     s.DisableStrictSSL()
        ///     .ExportCollectionTo("./collection-export.json")
        ///     .UseJsonReporter("./json-report.json"));
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void RunCollection(this ICakeContext ctx, FilePath collectionFile,
            Action<NewmanSettings> configure)
        {
            if (ctx == null) throw new ArgumentNullException(nameof(ctx));
            if (collectionFile == null) throw new ArgumentNullException(nameof(collectionFile));
            var runner = new NewmanRunner(ctx.FileSystem, ctx.Environment, ctx.ProcessRunner, ctx.Tools, ctx.Log);
            var settings = new NewmanSettings();
            configure?.Invoke(settings);
            runner.RunTool(collectionFile, settings);
        }
    }
}