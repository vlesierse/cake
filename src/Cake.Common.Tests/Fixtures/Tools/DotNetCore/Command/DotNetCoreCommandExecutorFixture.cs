using Cake.Common.Tools.DotNetCore;
using Cake.Common.Tools.DotNetCore.Command;

namespace Cake.Common.Tests.Fixtures.Tools.DotNetCore.Command
{
    internal sealed class DotNetCoreCommandExecutorFixture : DotNetCoreFixture<DotNetCoreSettings>
    {
        public string Path { get; set; }

        public string Command { get; set; }

        public string Arguments { get; set; }

        protected override void RunTool()
        {
            var tool = new DotNetCoreCommandExecutor(FileSystem, Environment, ProcessRunner, Globber);
            tool.Execute(Path, Command, Arguments, Settings);
        }
    }
}
