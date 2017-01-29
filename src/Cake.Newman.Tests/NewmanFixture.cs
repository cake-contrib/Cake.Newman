using System;
using Cake.Core.IO;
using Cake.Testing;
using Cake.Testing.Fixtures;

namespace Cake.Newman.Tests
{
    public class NewmanFixture : ToolFixture<NewmanSettings>
    {
        internal FilePath InputFile {get;set;}

        public NewmanFixture () : base("newman")
        {
            Settings = Settings ?? new NewmanSettings();
            InputFile = "./collection.json";
            FileSystem.CreateFile(InputFile);
        }

        public NewmanFixture(NewmanSettings settings) : this() {
            Settings = settings;
        }

        public NewmanFixture(Action<NewmanSettings> settings) : this() {
            ActionSettings = settings;
        }

        protected override void RunTool()
        {
            var tool = new NewmanRunner(FileSystem, Environment, ProcessRunner, Tools, new FakeLog());
            ActionSettings?.Invoke(Settings);
            tool.RunTool(InputFile, Settings);
        }

        internal Action<NewmanSettings> ActionSettings { get; set; }
    }
}