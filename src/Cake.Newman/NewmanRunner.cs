using System;
using System.Collections.Generic;
using System.IO;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Newman
{
    internal class NewmanRunner : Tool<NewmanSettings>
    {
        public NewmanRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
            IToolLocator tools, ICakeLog log) : base(fileSystem, environment, processRunner, tools)
        {
            Log = log;
            FileSystem = fileSystem;
        }

        private ICakeLog Log { get; }
        private IFileSystem FileSystem { get; }

        protected override string GetToolName() => "Newman";

        protected override IEnumerable<string> GetToolExecutableNames()
        {
            yield return "newman";
            yield return "newman.cmd";
            yield return "newman.sh";
        }

        internal void RunTool(FilePath collectionFile, NewmanSettings settings)
        {
            if (collectionFile == null) throw new ArgumentNullException(nameof(collectionFile));
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            if (!FileSystem.Exist(collectionFile)) throw new FileNotFoundException(collectionFile.FullPath);
            var args = new ProcessArgumentBuilder();
            args.Append("run");
            args.Append(collectionFile.FullPath);
            settings.Build(args);
            Log.Debug(args.Render());
            Run(settings, args);
        }
    }
}