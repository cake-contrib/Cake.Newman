using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;

namespace Cake.Newman
{
    [CakeAliasCategory("Postman")]
    [CakeNamespaceImport("Cake.Newman")]
    [CakeNamespaceImport("Cake.Newman.Reporters")]
    public static class NewmanAliases
    {
        [CakeMethodAlias]
        public static void RunCollection(this ICakeContext ctx, FilePath collectionFile)
        {
            if (ctx == null) throw new ArgumentNullException(nameof(ctx));
            if (collectionFile == null) throw new ArgumentNullException(nameof(collectionFile));
            var runner = new NewmanRunner(ctx.FileSystem, ctx.Environment, ctx.ProcessRunner, ctx.Tools, ctx.Log);
            runner.RunTool(collectionFile, new NewmanSettings());
        }

        [CakeMethodAlias]
        public static void RunCollection(this ICakeContext ctx, FilePath collectionFile, NewmanSettings settings)
        {
            if (ctx == null) throw new ArgumentNullException(nameof(ctx));
            if (collectionFile == null) throw new ArgumentNullException(nameof(collectionFile));
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            var runner = new NewmanRunner(ctx.FileSystem, ctx.Environment, ctx.ProcessRunner, ctx.Tools, ctx.Log);
            runner.RunTool(collectionFile, settings);
        }

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